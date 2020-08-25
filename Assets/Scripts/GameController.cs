using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController instance;

	public GameObject gameOverLayer;

	public bool isGameOver = false;

	public bool showCountdown = false;
	public float delayTime = 4.2f;
	public int score;
	public float coolDownTime = 5.0f;
	public float soundEffectVolumn = 0.05f;

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

	private void Update()
	{
		if (isGameOver)
		{
			gameOverLayer.SetActive(true);
		}
	}

}
