using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
	[SerializeField] ParticleSystem fire;

	public void Water()
	{
		ParticleSystem.MainModule main = fire.main;
		main.startColor = Random.ColorHSV();
		ParticleSystem.MinMaxGradient color = fire.colorOverLifetime.color;
		for (int i = 0; i < color.gradient.colorKeys.Length; i++)
		{
			color.gradient.colorKeys[i].color = Random.ColorHSV();
		}
	}
}
