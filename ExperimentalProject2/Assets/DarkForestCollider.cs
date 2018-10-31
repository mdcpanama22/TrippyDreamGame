using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkForestCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
       
        Debug.Log(other.transform.GetChild(0).gameObject.name);
        if (other.transform.GetChild(0).gameObject.tag == "MainCamera")
        {
            SkyBoxShifter SH = other.transform.GetChild(0).gameObject.GetComponent<SkyBoxShifter>();
            SH.DayTypeB = !SH.DayTypeB;

            if (SH.DayTypeB)
                SH.DayType = SkyBoxShifter.TimeOfDay.DarkForest;
            else
                SH.DayType = SkyBoxShifter.TimeOfDay.Main;
        }
    }
}
