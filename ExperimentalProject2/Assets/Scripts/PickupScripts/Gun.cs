using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {


    AudioSource audio;
    ParticleSystem particles;

    bool active = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        
    }

    public void Grab(GameObject obj)
    {
        transform.localPosition = new Vector3(0.34f, -0.4f, 0.8f);
        transform.localRotation = Quaternion.Euler(new Vector3(0, -180f, 0f));
    }

    public void Use(GameObject obj)
    {
        if (!active)
        {
            active = true;
            audio.Play();
            particles.Play();
        } else
        {
            active = false;
            audio.Stop();
            particles.Stop();
        }
    }

    public void Drop(GameObject obj)
    {
        active = false;
        audio.Stop();
        particles.Stop();
    }
}
