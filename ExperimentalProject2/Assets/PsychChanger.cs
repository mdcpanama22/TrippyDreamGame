using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychChanger : MonoBehaviour {

    public Material[] gMaterials;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Change", 2.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Change()
    {
     foreach(Transform child in transform)
        {
            child.gameObject.GetComponent<MeshRenderer>().material = gMaterials[Random.Range(0, gMaterials.Length)];
        }
        

    }
}
