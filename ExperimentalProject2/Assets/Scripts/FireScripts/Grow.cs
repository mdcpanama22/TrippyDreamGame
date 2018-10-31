using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
	[SerializeField] ParticleSystem fire;
	[SerializeField] float growth = 0.25f;

	public void Water()
	{
		Debug.Log("AHHA");
		var startSize = fire.main.startSize;
		startSize.constant += growth;
	}
}
