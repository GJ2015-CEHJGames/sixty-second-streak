using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
	enum GameStates
	{Title, About, Gameplay, Endgame, Countdown};
	private GameStates currGameState;
	// UI
	//public GameObject header;
	//public GameObject startButton;
	//public GameObject creditsButton;
	public GameObject titlePanel;
	public GameObject creditsPanel;
	public GameObject tallyPanel;
	public GameObject mainPanel;
	public GameObject genderPanel;
	public GameObject playerObjF;
	public GameObject playerObjM;
	public bool isMale;

	public TopDownCameraFollow tdcf;
	public float countdownTimer = 3;
	public float gameTimer;
	public int score = 0;
	public bool gameOver = false;
	public Text scoreText;
	public Text timerText;
	public Text tallyText;
	public Text countdownText;
	public Color color1;
	public Color color2;

	public Transform NPCs;
	public Transform Trees;
	public GameObject plyr;

	public AudioSource audioSource;
	public AudioClip maleSelectSound;
	public AudioClip femaleSelectSound;

	// Use this for initialization
	void Start() 
	{
		currGameState = GameStates.Title;
		//Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		switch (currGameState)
		{
		// Countdown
		case GameStates.Countdown:
			if (countdownTimer > 0)
			{
				countdownTimer -= Time.deltaTime;
				countdownText.text = countdownTimer.ToString("n0") == "0" ? "Go!!" : countdownTimer.ToString("n0");
			}
			else if (countdownTimer <= 0)
			{
				countdownText.gameObject.SetActive(false);
				StartGame();
			}
			break;
		// Gameplay
		case GameStates.Gameplay:
			if (!gameOver)
			{
				if (gameTimer > 0)
				{
					gameTimer -= Time.deltaTime;
					if (gameTimer <= 10)
					{
						timerText.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time * 2, gameTimer / 5.0f));
					}
				}
				else
				{
					gameOver = true;
					currGameState = GameStates.Endgame;
					Time.timeScale = 0;
					mainPanel.SetActive(false);
					tallyPanel.SetActive(true);
					tallyText.text = score.ToString();
					Destroy(plyr);
				}
			}
			
			scoreText.text = "SCORE-" + score.ToString();
			timerText.text = "TIMER-" + gameTimer.ToString("n0");
			break;
		}

	}

	public void StartClicked()
	{
		titlePanel.SetActive(false);
		genderPanel.SetActive(true);
	}

	public void MaleSelected()
	{
		isMale = true;
		genderPanel.SetActive(false);
		currGameState = GameStates.Countdown;
		mainPanel.SetActive(true);
		Time.timeScale = 1;
		audioSource.clip = maleSelectSound;
		audioSource.Play();
	}

	public void FemaleSelected()
	{
		isMale = false;
		genderPanel.SetActive(false);
		currGameState = GameStates.Countdown;
		mainPanel.SetActive(true);
		Time.timeScale = 1;
		audioSource.clip = femaleSelectSound;
		audioSource.Play();
	}

	public void StartGame()
	{
		audioSource.Play();
		currGameState = GameStates.Gameplay;
		
		if (isMale)
		{plyr = Instantiate(playerObjM, transform.position, transform.rotation) as GameObject;}
		else
		{plyr = Instantiate(playerObjF, transform.position, transform.rotation) as GameObject;}
		
		//plyr.GetComponent(PlayerController).gmmgr = this.GetComponent(GameManager);
		tdcf.playerTransform = plyr.transform;
	}

	public void CreditsClicked()
	{
		titlePanel.SetActive(false);
		creditsPanel.SetActive(true);
	}

	public void CreditsBackClicked()
	{
		titlePanel.SetActive(true);
		creditsPanel.SetActive(false);
	}

	public void ReplayClicked()
	{
		tallyPanel.SetActive(false);
		mainPanel.SetActive(true);
		gameTimer = 60;
		score = 0;
		scoreText.text = "SCORE: " + score.ToString();
		timerText.text = "TIMER: " + gameTimer.ToString("n0");
		//PlayerController plyrScr = plyr.GetComponent("PlayerController") as PlayerController;
		//plyrScr.ResetPos();
		for (int i = 0; i < NPCs.childCount; i++)
		{
			NPCController npcctrl = NPCs.GetChild(i).GetComponent("NPCController") as NPCController;
			npcctrl.ResetPos();
		}
		for (int j = 0; j < Trees.childCount; j++)
		{
			TreeController trctrl = Trees.GetChild(j).GetComponent("TreeController") as TreeController;
			trctrl.onFire = false;
		}
		Time.timeScale = 1;
		currGameState = GameStates.Countdown;
		countdownTimer = 3;
		countdownText.gameObject.SetActive(true);
		gameOver = false;
		Camera.main.transform.position = new Vector3(0, -11.35f, -10);
	}

	public void MainMenuClicked()
	{
		Application.LoadLevel(Application.loadedLevel);
		//titlePanel.SetActive(true);
		//tallyPanel.SetActive(false);
	}
}
