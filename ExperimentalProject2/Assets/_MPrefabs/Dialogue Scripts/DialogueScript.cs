using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour {

    public GameObject canvas;
    public FancyText fancyText;

    [TextArea]
    public string[] Dialogue;

    int index = 0;

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
        /*
        if (active) {
            if (Vector3.Distance(player.transform.position, transform.position) > 6f) {
                active = false;
                canvas.SetActive(false);
            }
        } */
	}


    public void Trigger()
    {
        if (fancyText.revealing)
        {
            fancyText.FinishLine();
        }
        else
        {
            if (index >= Dialogue.Length)
            {
                active = false;
                canvas.SetActive(false);
                index = 0;
            }
            else
            {
                active = true;
                canvas.SetActive(true);
                fancyText.SetText(Dialogue[index]);
                index += 1;
            }
        }
    }
}
