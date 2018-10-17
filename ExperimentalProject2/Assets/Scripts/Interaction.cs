using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * How this works. on update I call a raycast that will search for when the player interacts with something when left clicking
 * the hit value holds the gameobject it hit
 * You will differentiate what object is hit based on the tags (example is given with Object_I)
 * Ideally all the starting interactions will be coded on the _IndividualInteractions script, which will then call the corresponding method for
 * each specific interaction
 * 
 * this should be the starting point of every click interaction
 * 
 * THINGS TO REMEMBER WHEN DEBUGGING:

        >Make sure that the gameobject you are interacting with has the correct tag
        >Make sure that the first call to your interaction is done on the _IndividualInterataction script,
        this way you can call the start of the function via the script hit.transform.GetComponent<_IndividualInteraction>().NAME_OF_INTERACTION();
        >
 */



public class Interaction : MonoBehaviour {

    public AudioSource Yes;
    public AudioSource No;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //Center of camera view, where the cursor has been manually placed on the UI
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * 500, Color.red);

                //CHECK FOR WHICH GAMEOBJECT YOU COLLIDED WITH TO THEN START INTERACTION
				if(hit.transform.tag == "Object_I"){
                    hit.transform.GetComponent<_IndividualInteraction>().BoxTestInteraction();
				}else if(hit.transform.tag == "Object_IE") {
                    hit.transform.GetComponent<_IndividualInteraction>().BoxDisplacement();
				}
                else if (hit.transform.tag == "Interactable" && hit.distance < 3f)
                {
                    hit.transform.gameObject.SendMessage("Trigger");
                }
                else if (hit.transform.tag == "Pickup" && hit.distance < 3f)
                {
                    GetComponent<Pickup>().Grab(hit.transform.gameObject);
                } else
                {
                    GetComponent<Pickup>().Drop();
                }
            }
            else 
            {
                GetComponent<Pickup>().Drop();
            }
        } 
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Yes.Play();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            No.Play();
        }
    }
}
