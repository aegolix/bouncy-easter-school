using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
	public float rockSpeedY = 5, rockSpeedX = -5;
	private bool move = true;
	public float thrust = 10.0f;

	// Start is called before the first frame update
	void Start()
	{

	}
	
	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Bunny"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.transform.up * thrust, ForceMode2D.Impulse);
            move = false;
        }

        if (collision.gameObject.name == "left_bound" || collision.gameObject.name == "right_bound")
        {
            Destroy(transform.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.showCountdown && !GameController.instance.isGameOver)
		{
			if (move)
			{
				transform.Translate(transform.up * Time.deltaTime * rockSpeedY);
				transform.Translate(transform.right * Time.deltaTime * rockSpeedX);
			}				

			if (Camera.main.transform.position.y + Camera.main.orthographicSize * Screen.height / Screen.width
				<= transform.position.y - transform.GetComponent<SpriteRenderer>().bounds.size.y / 2)
			{
				Destroy(transform.gameObject);
			}
		}
    }
}
