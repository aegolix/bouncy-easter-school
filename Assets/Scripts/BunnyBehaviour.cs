using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBehaviour : MonoBehaviour
{
	private Animator anim;
	private Rigidbody2D rb2d;
	private Vector2 initPostion;

	private bool jump = false;
    private bool crouch = false;
	public bool isDead = false;

	private AudioSource bunnySoundEffect;
	public AudioClip jumpEffect;
	public AudioClip hitGroundEffect;

    void Awake()
    {
		anim = GetComponent<Animator>();
		anim.enabled = false;
		rb2d = GetComponent<Rigidbody2D>();
		initPostion = transform.position;
	}

	void Start()
	{
		bunnySoundEffect = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
    {
		if (GameController.instance.showCountdown == true)  //GMS.loadScene == true
		{
			anim.enabled = true;

			if (isDead) { return; }
		}
    }

    void FixedUpdate()
    {
		if (GameController.instance.showCountdown && !GameController.instance.isGameOver)
		{
			// Move our character
			//controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
			//jump = false;

			transform.position = Vector2.MoveTowards(transform.position, initPostion, 1 * Time.deltaTime);
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("ground"))
		{
			bunnySoundEffect.PlayOneShot(hitGroundEffect, GameController.instance.soundEffectVolumn);
			isDead = true;
			GameController.instance.isGameOver = true;
		}

		if (collision.gameObject.name.Contains("rock"))
		{
			bunnySoundEffect.PlayOneShot(jumpEffect, GameController.instance.soundEffectVolumn);
		}
	}
}