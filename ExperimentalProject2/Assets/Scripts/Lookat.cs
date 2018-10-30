using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour {

    bool triggered = false;
    GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (triggered)
        {
            player.transform.GetChild(0).LookAt(transform);
        }

	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RealFPSController")
        {
            player = other.gameObject;
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "RealFPSController")
        {
            triggered = false;
        }
    }

}
