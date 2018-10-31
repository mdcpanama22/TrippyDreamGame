using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatScript : MonoBehaviour
{
	[SerializeField] GameObject canvas;
	[SerializeField] FancyText fancyText;
	[SerializeField] Font font;
	[SerializeField] float activeDistance;

	bool active = false;
	GameObject player;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("FPSController");
		if (player == null)
			player = GameObject.Find("RealFPSController");
	}
	
	// Update is called once per frame
	void Update()
	{
		if (active)
		{
			if (Vector3.Distance(player.transform.position, transform.position) > activeDistance)
			{
				active = false;
				canvas.SetActive(false);
			}
			else
			{
				if (Input.GetKeyDown(KeyCode.Y))
					return;
				else if (Input.GetKeyDown(KeyCode.T))
					return;
			}
		}
	}

	void Trigger()
	{
		if (fancyText.revealing)
		{
			fancyText.FinishLine();
		}
		else if (!active)
		{
			active = true;
			canvas.SetActive(true);
		}
	}
}
