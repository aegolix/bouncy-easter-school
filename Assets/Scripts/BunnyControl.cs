using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyControl : MonoBehaviour
{
	private int childBunyCount = 0;

	// Start is called before the first frame update
	void Start()
	{
		childBunyCount = transform.childCount;
	}

	public void SpawnNewBunny()
	{
		if (GameController.instance.showCountdown && !GameController.instance.isGameOver)
		{
			GameObject chosen = transform.GetChild(Random.Range(1, childBunyCount - 1)).gameObject;
			GameObject aBunny = Instantiate(chosen, transform) as GameObject;
			aBunny.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
