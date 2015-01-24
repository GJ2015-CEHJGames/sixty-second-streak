using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public float gameTimer;
	public int score = 0;
	public bool gameOver = false;

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
	}
}
