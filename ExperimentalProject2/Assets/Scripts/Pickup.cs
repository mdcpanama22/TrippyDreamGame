using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public GameObject held;
    public Vector3 heldOffset = new Vector3(0f, -0.4f, 0.8f);
    public Quaternion heldRotation = Quaternion.identity;

    GameObject pickupUI;

    private void Start()
    {
        pickupUI = GameObject.Find("PickupUI");
        pickupUI.SetActive(false);
    }

    void Update() {
        if (held != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                held.SendMessage("Use", this.gameObject, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    public void Grab(GameObject obj)
    {
        pickupUI.SetActive(true);
        if (held != null) { Drop(); }
        held = obj;
        held.transform.SetParent(Camera.main.transform);
        held.transform.localPosition = heldOffset;
        held.transform.localRotation = heldRotation;
        held.GetComponent<Collider>().enabled = false;
        if (held.GetComponent<Rigidbody>() != null)
        {
            held.GetComponent<Rigidbody>().isKinematic = true;
        }
        held.SendMessage("Grab", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }

    public void Drop()
    {
        if (held != null)
        {
            pickupUI.SetActive(false);
            held.transform.parent = null;
            held.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1f;
            held.GetComponent<Collider>().enabled = true;
            if (held.GetComponent<Rigidbody>() != null)
            {
                held.GetComponent<Rigidbody>().isKinematic = false;
                held.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 3f;
            }
            held.SendMessage("Drop", this.gameObject, SendMessageOptions.DontRequireReceiver);
            held = null;
        }
    }
}
