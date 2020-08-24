using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
	private bool move = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Bunny"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
            move = false;
        }

        if (collision.gameObject.name == "left_bound" || collision.gameObject.name == "right_bound")
        {
            Destroy(transform.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.showCountdown)
		{
			if (move) transform.Translate(transform.up * Time.deltaTime * 25);
			transform.Translate(transform.right * Time.deltaTime * (-10));

			if (Camera.main.transform.position.y + Camera.main.orthographicSize * Screen.height / Screen.width
				<= transform.position.y - transform.GetComponent<SpriteRenderer>().bounds.size.y / 2)
			{
				Destroy(transform.gameObject);
			}
		}
    }
}
