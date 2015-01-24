using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public float gameTimer;
	public int score = 0;
	public bool gameOver = false;
	public Text scoreText;
	public Text timerText;

	// Use this for initialization
	void Start() 
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		if (!gameOver)
		{
			if (gameTimer > 0)
			{gameTimer -= Time.deltaTime;}
			else
			{
				gameOver = true;
				Time.timeScale = 0;
				Debug.Log("Game Over! Final Score: " + score);
			}
		}

		scoreText.text = "SCORE: " + score.ToString();
		timerText.text = "TIMER: " + gameTimer.ToString("n0");
	}
}
