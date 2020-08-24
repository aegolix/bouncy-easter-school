using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
	Text score;
	public float timer = 0.0f;
	
	// Start is called before the first frame update
    void Start()
    {
		score = GameObject.Find("ScoreNum").GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
		if (GameController.instance.showCountdown == true)
		{
			timer += Time.deltaTime;
			GameController.instance.to_score = (int) (timer % 60);
			score.text = GameController.instance.to_score.ToString();
		}
	}
}
