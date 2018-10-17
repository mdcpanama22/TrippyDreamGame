using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : MonoBehaviour {

    public AudioClip[] AudioClips;


    private void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    private void Update()
    {
        if (!GetComponentInChildren<AudioSource>().isPlaying)
        {
            GetComponent<Animator>().enabled = false;
        }
    }

    public void Grab(GameObject obj)
    {
        transform.localPosition = new Vector3(-0.3f, -1.8f, 0.7f);
        transform.localRotation = Quaternion.Euler(new Vector3(0, -130f, -15f));
    }

    public void Use(GameObject obj)
    {
        GetComponentInChildren<AudioSource>().clip = AudioClips[Random.Range(0, AudioClips.Length)];
        GetComponentInChildren<AudioSource>().Play();
        GetComponent<Animator>().enabled = true;
    }

    public void Drop(GameObject obj)
    {
        GetComponent<Animator>().enabled = false;
        GetComponentInChildren<AudioSource>().Stop();
    }
}
