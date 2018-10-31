using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DancingBusiness : MonoBehaviour {

    public GameObject canvas;
    public FancyText fancyText;

    public AudioClip[] DialogueAudio;

    [TextArea]
    public string[] Dialogue;

    int index = 0;

    bool active = false;

    GameObject player;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("FPSController");
        if (player == null) {
             player = GameObject.Find("RealFPSController");
        }
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (active) {
            if (Vector3.Distance(player.transform.position, transform.position) > 6f) {
                active = false;
                canvas.SetActive(false);
                audio.Stop();
            }
        }
	}


    public void Trigger()
    {
        if (fancyText.revealing)
        {
            fancyText.FinishLine();
        }
        else
        {
            if (active)
            {
                active = false;
                canvas.SetActive(false);
                audio.Pause();
            }
            else
            {
                active = true;
                canvas.SetActive(true);
                if (index == Dialogue.Length)
                {
                    index = 0;
                }

                int x = UnityEngine.Random.Range(0, 4);
                if (x == 0) { fancyText.effectType = FancyText.EffectType.RAINBOW; }
                if (x == 1) { fancyText.effectType = FancyText.EffectType.SWIVEL; }
                if (x == 2) { fancyText.effectType = FancyText.EffectType.WAVY; }
                if (x == 3) { fancyText.effectType = FancyText.EffectType.PULSE; }
                fancyText.SetText(Dialogue[index]);
                audio.clip = DialogueAudio[index];
                audio.Play();
                index += 1;
            }
        }
    }
}
