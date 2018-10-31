using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour {

    public AudioSource Music;
    public AudioSource Music_Snow;

    // Use this for initialization
    void Start () {
        Music.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Snow")
        {
            Music_Snow.Play();
            Music.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Snow")
        {
            Music.Play();
            Music_Snow.Stop();
        }
    }
}
