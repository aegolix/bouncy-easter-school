using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControl : MonoBehaviour
{
	private int childRockCount = 0;
	private float coolDownTime = 0.36f;
	private float lastTime = 0;

	// Start is called before the first frame update
	void Start()
	{
		childRockCount = transform.childCount;
		//rockSoundEffect = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (GameController.instance.showCountdown && !GameController.instance.isGameOver && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
		//if (StartGame.start && Input.touchCount > 0)
		{
			if (Time.time - lastTime > coolDownTime)
			{
				//rockSoundEffect.PlayOneShot(pushRockEffect, GameController.instance.soundEffectVolumn);

				Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				//Vector3 wp = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
				GameObject chosen = transform.GetChild(Random.Range(0, childRockCount - 1)).gameObject;
				GameObject aPole = Instantiate(chosen, new Vector3(wp.x, -chosen.GetComponent<BoxCollider2D>().size.y, 0), Quaternion.identity, transform.transform) as GameObject;
				aPole.SetActive(true);

				lastTime = Time.time;
			}
		}
	}
}