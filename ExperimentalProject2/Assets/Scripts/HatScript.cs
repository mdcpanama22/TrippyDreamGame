using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatScript : MonoBehaviour
{
	[SerializeField] GameObject canvas;
	[SerializeField] string hatName;
	[SerializeField] Text text;
	[SerializeField] float displayTime = 5f;
	float startDisplayTime = Mathf.Infinity;

	private void Update()
	{
		if (Time.time - startDisplayTime >= displayTime)
		{
			canvas.SetActive(false);
			Destroy(gameObject);
		}
	}

	void Trigger()
	{
		GetComponent<Collider>().enabled = false;
		foreach (Renderer r in GetComponentsInChildren<Renderer>())
			r.enabled = false;
		startDisplayTime = Time.time;
		canvas.SetActive(true);
		text.text = "You put on the " + hatName;
	}
}
