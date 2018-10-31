using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bucket : MonoBehaviour
{
	[SerializeField] GameObject water;
	[SerializeField] AudioClip fillSound;
	[SerializeField] AudioClip emptySound;
	
	private bool full = false;
	private AudioSource audioSource;

	private void Start()
	{
		water.SetActive(false);
		audioSource = GetComponent<AudioSource>();
	}

	public void Grab(GameObject obj)
	{
		transform.localPosition = new Vector3(0.2f, -0.5f, 0.8f);
		transform.localRotation = Quaternion.Euler(new Vector3(-25f, 0, 0));
	}

	public void Use(GameObject obj)
	{
		if (!full)
		{
			RaycastHit hit;
			//Center of camera view, where the cursor has been manually placed on the UI
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			if (Physics.Raycast(ray, out hit, 1000f, LayerMask.GetMask("Water")))
			{
				full = true;
				water.SetActive(true);
				if (fillSound)
				{
					audioSource.clip = fillSound;
					audioSource.Play();
				}
			}
		}
		else
			Empty();
	}

	public void Drop(GameObject obj)
	{
		Empty();
	}

	private void Empty()
	{
		full = false;
		water.SetActive(false);
		if (emptySound)
		{
			audioSource.clip = emptySound;
			audioSource.Play();
		}
	}
}
