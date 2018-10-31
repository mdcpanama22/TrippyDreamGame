using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGuy : MonoBehaviour
{
	public GameObject canvas;
	public FancyText fancyText;

	[TextArea]
	public string[] waterResponse;
	int index = 0;

	bool active = false;

	GameObject player;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("FPSController");
		if (player == null)
		{
			player = GameObject.Find("RealFPSController");
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (active)
		{
			if (Vector3.Distance(player.transform.position, transform.position) > 6f)
			{
				active = false;
				canvas.SetActive(false);
				if (GetComponent<AudioSource>() != null && GetComponent<AudioSource>().isPlaying) { GetComponent<AudioSource>().Pause(); }
			}
			else if (Input.GetMouseButtonDown(0))
			{
				if (index < waterResponse.Length)
				{
					fancyText.SetText(waterResponse[index]);
					index += 1;
				}
				else
				{
					index = 0;
					active = false;
					canvas.SetActive(false);
					if (GetComponent<AudioSource>() != null && GetComponent<AudioSource>().isPlaying) { GetComponent<AudioSource>().Pause(); }
				}
			}
		}
	}

	public void Water()
	{
		if (fancyText.revealing)
		{
			fancyText.FinishLine();
		}
		else
		{
			if (!active)
			{
				active = true;
				canvas.SetActive(true);
				if (GetComponent<AudioSource>() != null && !GetComponent<AudioSource>().isPlaying) { GetComponent<AudioSource>().Play(); }
			}
		}
	}
}
