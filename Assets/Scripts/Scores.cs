using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
	private TMPro.TextMeshProUGUI score;
	public float timer = 0.0f;

	// Start is called before the first frame update
	void Start()
	{
		score = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		if (GameController.instance.showCountdown && !GameController.instance.isGameOver)
		{
			timer += Time.deltaTime * 10;
			GameController.instance.score = (int)timer;
			score.text = ((int)timer).ToString();
		}
	}
}