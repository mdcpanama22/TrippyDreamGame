using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _IndividualInteraction : MonoBehaviour {

    public GameObject textbox;
	// Use this for initialization
	void Start () {
        textbox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BoxTestInteraction()
    {
        textbox.SetActive(!textbox.activeSelf);
    }
}
