using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	private Camera cam;
    private GameObject lb, rb;
	
	private float delayTime = 4.0f;

	//Start is called before the first frame update
	void Awake()
	{
		cam = Camera.main;
		lb = GameObject.Find("left_bound");
		rb = GameObject.Find("right_bound");
	}

	void Start()
    {
		Time.timeScale = 1;
		StartCoroutine(GameController.instance.Delay(GameController.instance.delayTime));
	}

	//Update is called once per frame
	void Update()
	{
		if (GameController.instance.showCountdown) //GMS.loadScene == true
		{
			//Time.timeScale = 1;

			lb.transform.position = new Vector2(cam.transform.position.x - cam.orthographicSize * Screen.width / Screen.height - lb.GetComponent<SpriteRenderer>().bounds.size.x, lb.transform.position.y);
			rb.transform.position = new Vector2(cam.transform.position.x + cam.orthographicSize * Screen.width / Screen.height + lb.GetComponent<SpriteRenderer>().bounds.size.x, lb.transform.position.y);
		}

		//if (started) //&& Input.GetButtonDown("Jump"))

			///if (!start && Input.touchCount > 0)
	}
}
