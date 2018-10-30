using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AppleGuy : MonoBehaviour {

    public GameObject canvas;
    public FancyText fancyText;

    List<Joke> untoldJokes;

    [TextArea]
    public string[] FirstMeet;
    [TextArea]
    public string[] Dialogue;

    int index = 0;

    bool firstTime = true;

    bool active = false;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("FPSController");
        if (player == null) {
             player = GameObject.Find("RealFPSController");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (active) {
            if (Vector3.Distance(player.transform.position, transform.position) > 6f) {
                active = false;
                canvas.SetActive(false);
                if (GetComponent<AudioSource>() != null && GetComponent<AudioSource>().isPlaying) { GetComponent<AudioSource>().Pause(); }
            }
        }
	}


    public void Trigger()
    {
        if (fancyText.revealing)
        {
            fancyText.FinishLine();
        }
        else if (firstTime)
        {
            if (!active)
            {
                active = true;
                canvas.SetActive(true);
                if (GetComponent<AudioSource>() != null && !GetComponent<AudioSource>().isPlaying) { GetComponent<AudioSource>().Play(); }
            }
            if (index < FirstMeet.Length)
            {
                fancyText.SetText(FirstMeet[index]);
                index += 1;
            }
            else
            {
                index = 0;
                firstTime = false;
                active = false;
                canvas.SetActive(false);
                if (GetComponent<AudioSource>() != null && GetComponent<AudioSource>().isPlaying) { GetComponent<AudioSource>().Pause(); }
            }
        }
        else
        {
            if (active)
            {
                active = false;
                canvas.SetActive(false);
                if (GetComponent<AudioSource>() != null && GetComponent<AudioSource>().isPlaying) { GetComponent<AudioSource>().Pause(); }
            }
            else
            {
                active = true;
                canvas.SetActive(true);
                if (GetComponent<AudioSource>() != null && !GetComponent<AudioSource>().isPlaying) { GetComponent<AudioSource>().Play(); }
                    if (index == Dialogue.Length)
                {
                    index = 0;
                }
                fancyText.SetText(Dialogue[index]);
                index += 1;
            }
        }
    }
}
