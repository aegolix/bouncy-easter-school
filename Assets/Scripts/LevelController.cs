using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
	private TMPro.TextMeshProUGUI levelText;

	private int interval = 100;
	private int curLevel = 1;

	public GameObject bunnyControllObject;

	private BunnyControl bunnyController;
	
	// Use this for initialization
	void Start()
	{
		levelText = GameObject.Find("LevelNum").GetComponent<TMPro.TextMeshProUGUI>();
		bunnyController = bunnyControllObject.GetComponent<BunnyControl>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!GameController.instance.isGameOver)
			if (GameController.instance.score / interval + 1 > curLevel)
			{
				curLevel = GameController.instance.score / interval + 1;
				levelText.text = curLevel.ToString();
				bunnyController.SpawnNewBunny();

				if (GameController.instance.coolDownTime < 10)
					GameController.instance.coolDownTime += 2;

				//switch (curLevel)
				//{
				//	case 1:
				//		break;
				//	case 2:

				//		break;
				//	case 3:
				//		bunnyController.SpawnNewBunny();
				//		break;
				//	case 4:
				//		bunnyController.SpawnNewBunny();
				//		break;
				//	case 5:
				//		bunnyController.SpawnNewBunny();
				//		break;
				//	default:
				//		break;
				//}
			}		
		}
}
