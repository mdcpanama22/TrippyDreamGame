using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTouchWater : MonoBehaviour {

    Vector3 respawnPoint;

    bool cooldown = true;

	// Use this for initialization
	void Start () {
        respawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Respawn")
        {
            transform.position = respawnPoint;
        } else if (cooldown)
        {
            respawnPoint = transform.position + Vector3.up * 0.5f;
            cooldown = false;
            StartCoroutine("Cooldown");
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
        cooldown = true;
    }
}
