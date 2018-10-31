using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	[SerializeField] Transform target;
	private GameObject player;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("FPSController");
		if (player == null)
		{
			player = GameObject.Find("RealFPSController");
		}
	}
	
	public void Water()
	{
		player.transform.position = target.position;
	}
}
