using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveController : MonoBehaviour
{
	public static LiveController instance;
	//private ZeroLivesController mZeroLivesController;
	private Animator livesAnim;

	public int lives = 4;
	public bool hitGround = false;
	public int maxSecond = 20;
	public int seconds;
	public bool isGameOver = false;

	public Coroutine lastRoutine = null;

	// Use this for initialization
	private void Awake()
	{
		seconds = maxSecond;
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this);
	}

	private void Start()
	{
		DontDestroyOnLoad(this);

		livesAnim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (seconds <= 0)
		{
			StopCoroutine(lastRoutine);
			GameController.instance.Die();
			seconds = maxSecond;
			//WtiteTextFile.WriteString("time.txt", "0");
			//mZeroLivesController.zeroLiveUI.gameObject.SetActive(false);
			lives = 4;
			//DummyFourAnim();
			//Debug.Log(lives + "");
		}
	}
	public void AddLife(int life)
	{
		if (GameController.instance.isGameOver) { return; }

		lives += life;

		if (lives > 4) lives = 4;
		//animate the hearts here
		switch (lives)
		{
			case 0:
				livesAnim.Play("zero");
				//ZeroLivesHandler();
				break;
			case 1:
				livesAnim.Play("one");
				break;
			case 2:
				livesAnim.Play("two");
				break;
			case 3:
				livesAnim.Play("three");
				break;
			case 4:
				livesAnim.Play("four");
				break;
		}
	}

	public void DummyOneAnim()
	{
		livesAnim.Play("one");
	}

	public void DummyFourAnim()
	{
		livesAnim.Play("four");
	}

	//public void ZeroLivesHandler()
	//{
	//	GameObject zeroLives = GameObject.Find("ZeroLives");
	//	mZeroLivesController = zeroLives.GetComponent<ZeroLivesController>();
	//	mZeroLivesController.zeroLiveUI.gameObject.SetActive(true);

	//	//start counting down
	//	lastRoutine = StartCoroutine(CountDown());

	//}
	//public IEnumerator CountDown()
	//{
	//	seconds = WtiteTextFile.ReadTime("time.txt");
	//	if (seconds == 0) seconds = maxSecond;
	//	while (seconds > 0)
	//	{
	//		seconds--;
	//		mZeroLivesController.CountDown.text = "" + seconds;
	//		yield return new WaitForSeconds(1);
	//	}
	//}
}
