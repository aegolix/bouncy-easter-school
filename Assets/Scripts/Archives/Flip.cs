using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
	private float x;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
	}

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.showCountdown == true)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= Mathf.Sign(transform.position.x - x);
			transform.localScale = theScale;
			x = transform.position.x;
		}
    }
}
