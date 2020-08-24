using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControl : MonoBehaviour
{
	private int childRockCount = 0;
	private bool coolDown = false;
	private float coolDownTime = 5.0f;

	// Start is called before the first frame update
	void Start()
    {
        childRockCount = transform.childCount;
	}

	void ResetCoolDown()
	{
		coolDown = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (GameController.instance.showCountdown && Input.GetMouseButtonDown(0)) //StartGame.started //GMS.loadScene == true
		//if (StartGame.start && Input.touchCount > 0)
		{
			if(coolDown == false)
			{
				Invoke("ResetCoolDown", coolDownTime);
				coolDown = true;
			}
			else
			{
				Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				//Vector3 wp = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
				GameObject chosen = transform.GetChild(Random.Range(0, childRockCount - 1)).gameObject;
				GameObject aPole = Instantiate(chosen, new Vector3(wp.x, -chosen.GetComponent<BoxCollider2D>().size.y, 0), Quaternion.identity, transform.transform) as GameObject;
				aPole.SetActive(true);

				ResetCoolDown();
			}
        }
    }
}
