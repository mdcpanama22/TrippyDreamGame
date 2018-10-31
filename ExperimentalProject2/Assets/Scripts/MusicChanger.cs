using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour {

    public AudioSource Music;
    public AudioSource Music_Snow;
    public AudioSource Music_Spooky;


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
        if (other.tag == "Spooky")
        {
            Music_Spooky.Play();
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
        if (other.tag == "Spooky")
        {
            Music.Play();
            Music_Spooky.Stop();
        }
    }
}
