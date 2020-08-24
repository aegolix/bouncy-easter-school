using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Animator anim;
	private Rigidbody2D rb2d;
	private Vector2 initPostion;

	public float runSpeed = 0f;
	private float lastTime = 0, threshold = 0.5f;

	private bool jump = false;
    private bool crouch = false;
	public bool isDead = false;

    void Awake()
    {
		anim = GetComponent<Animator>();
		anim.enabled = false;
		rb2d = GetComponent<Rigidbody2D>();
		initPostion = transform.position;
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
    {
		if (GameController.instance.showCountdown == true)  //GMS.loadScene == true
		{
			anim.enabled = true;
			runSpeed = 40f;

			if (isDead) { return; }

			Debug.Log("hit!");

			//horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			//if (Input.GetButtonDown("Jump"))
			//{
			//	jump = true;
			//}

			//if (Input.GetButtonDown("Crouch"))
			//{
			//	crouch = true;
			//}
			//else if (Input.GetButtonUp("Crouch"))
			//{
			//	crouch = false;
			//}
		}
    }

    void FixedUpdate()
    {
		if (GameController.instance.showCountdown == true)
		{
			// Move our character
			//controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
			//jump = false;

			//transform.position = Vector2.MoveTowards(transform.position, initPostion, 1 * Time.deltaTime);
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//if (collision.gameObject.name == "Reposition")
		//{
		//	reposition = true;
		//	rb2d.AddForce(new Vector2(-20f, -10f));

		//	GameController.Instance.scrollSpeed = -10f;
		//}

		if (collision.gameObject.name == "mountain0" || collision.gameObject.name == "mountain0_1" ||
			collision.gameObject.name == "mountain1" || collision.gameObject.name == "mountain1_1" ||
			collision.gameObject.name == "mountain2" || collision.gameObject.name == "mountain2_1")
		{
			Debug.Log("hit!");

			if (Time.time - lastTime > threshold)
			{
				if (LiveController.instance.lives > 0)
					LiveController.instance.AddLife(-1);
				else
				{
					isDead = true;
					rb2d.velocity = Vector2.zero;

					if (LiveController.instance.lives == 0)
						GameController.instance.ZeroDie();
					else
						GameController.instance.Die();
				}

				lastTime = Time.time;
			}
		}
	}
}