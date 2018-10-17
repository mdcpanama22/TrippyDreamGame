using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Text_Box : MonoBehaviour {

	    public GameObject textbox;

    private GameObject realText;
	// Use this for initialization
	void Start () {
        if(textbox != null)
            textbox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger()
    {
        if(realText == null)
        {
            realText = Instantiate(textbox, transform);
            realText.transform.position = new Vector3(transform.position.x, transform.position.y + 1.56f, transform.position.z);
        }
        realText.SetActive(!realText.activeSelf);
       // bool activeText = GameObject.Find("Dialogue_Manager").GetComponent<Dialogue>().active;

      //  GameObject.Find("Dialogue_Manager").GetComponent<Dialogue>().active = !activeText;
    }
}
