using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController instance;

	public GameObject gameOverText, ReplayButton;
	public bool isGameOver = false;

	public float to_score;
	public bool showCountdown = false;
	public float delayTime = 4.2f;

	float thresholdTime = 0.36f;
	float thresholdTimeForTime = 0.2f;
	float lastTime = 0;
	float lastTimeForTime = 0;

	public bool firstRun = true;
	public bool firstAppear = true;
	public bool replay = false;
	public bool toPause = false;
	public bool panelOpen = false;
	public bool startNew = false;

	// Use this for initialization
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	public IEnumerator Delay(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		showCountdown = true;
	}

	public void Die()
	{
		isGameOver = true;
		ReplayButton.SetActive(true);
		gameOverText.SetActive(true);
	}

	public void ZeroDie()
	{
		isGameOver = true;
		gameOverText.SetActive(true);
	}
}
