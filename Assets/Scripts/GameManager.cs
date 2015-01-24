using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
	enum GameStates
	{Title, About, Gameplay, Endgame};
	private GameStates currGameState;
	// UI
	public GameObject header;
	public GameObject startButton;

	public float gameTimer;
	public int score = 0;
	public bool gameOver = false;
	public Text scoreText;
	public Text timerText;

	// Use this for initialization
	void Start() 
	{
		currGameState = GameStates.Title;
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		switch (currGameState)
		{
		// Title
		case GameStates.Title:

			break;
		// About
		case GameStates.About:

			break;
		// Gameplay
		case GameStates.Gameplay:
			if (!gameOver)
			{
				if (gameTimer > 0)
				{gameTimer -= Time.deltaTime;}
				else
				{
					gameOver = true;
					currGameState = GameStates.Endgame;
					Time.timeScale = 0;
					Debug.Log("Game Over! Final Score: " + score);
				}
			}
			
			scoreText.text = "SCORE: " + score.ToString();
			timerText.text = "TIMER: " + gameTimer.ToString("n0");
			break;
		// Endgame
		case GameStates.Endgame:

			break;
		}

	}

	public void StartClicked()
	{
		currGameState = GameStates.Gameplay;
		header.SetActive(false);
		startButton.SetActive(false);
		Time.timeScale = 1;
	}
}
