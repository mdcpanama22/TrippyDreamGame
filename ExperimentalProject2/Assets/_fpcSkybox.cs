using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _fpcSkybox : MonoBehaviour {

    public Material mat1;
	// Use this for initialization
	void Start () {
        RenderSettings.skybox = mat1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
