using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCamera : MonoBehaviour
{
	[SerializeField] float flipTime = 5f;

	private bool flipping = false;
	private float flipStartTime = Mathf.Infinity;

	// Update is called once per frame
	void Update ()
	{
		if (flipping && Time.time - flipStartTime >= flipTime)
		{
			Camera.main.transform.Rotate(Vector3.forward, 180f);
		}
	}

	public void Water()
	{
		flipStartTime = Time.time;
		Camera.main.transform.Rotate(Vector3.forward, 180f);
	}
}
