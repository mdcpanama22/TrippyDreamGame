using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaboom : MonoBehaviour
{
	[SerializeField] GameObject explosion;
	[SerializeField] AudioSource audioSource;

	public void Water()
	{
		if (explosion)
			Instantiate(explosion, transform);
		if (audioSource)
			audioSource.Play();
	}
}
