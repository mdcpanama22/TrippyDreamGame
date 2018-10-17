using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : MonoBehaviour {

    public AudioClip[] AudioClips;

    AudioSource audio;

    float clipLoudness;
    float[] clipSampleData = new float[256];

    private void Start()
    {
        GetComponent<Animator>().enabled = false;
        audio = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        if (!audio.isPlaying)
        {
            GetComponent<Animator>().enabled = false;
        } else
        {
            audio.clip.GetData(clipSampleData, audio.timeSamples);
            clipLoudness = 0f;
            foreach(float sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= 256;
            clipLoudness -= 0.03f;
            clipLoudness *= 10f;
            clipLoudness = Mathf.Clamp01(clipLoudness);
            GetComponent<Animator>().Play("Talk", 0, clipLoudness / 2f);
            print(clipLoudness);
        }
    }

    public void Grab(GameObject obj)
    {
        transform.localPosition = new Vector3(-0.3f, -1.8f, 0.7f);
        transform.localRotation = Quaternion.Euler(new Vector3(0, -130f, -15f));
    }

    public void Use(GameObject obj)
    {
        audio.clip = AudioClips[Random.Range(0, AudioClips.Length)];
        audio.Play();
        GetComponent<Animator>().enabled = true;
    }

    public void Drop(GameObject obj)
    {
        GetComponent<Animator>().enabled = false;
        audio.Stop();
    }
}
