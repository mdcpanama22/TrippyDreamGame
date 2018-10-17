using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public GameObject held;
    public Vector3 heldOffset = new Vector3(0f, -0.4f, 0.8f);
    public Quaternion heldRotation = Quaternion.identity;

    void Update() {
        if (held != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                held.SendMessage("Use", this.gameObject);
            }
        }
    }

    public void Grab(GameObject obj)
    {
        if (held != null) { Drop(); }
        held = obj;
        held.transform.SetParent(Camera.main.transform);
        held.transform.localPosition = heldOffset;
        held.transform.localRotation = heldRotation;
        if (held.GetComponent<Rigidbody>() != null)
        {
            held.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void Drop()
    {
        if (held != null)
        {
            held.transform.parent = null;
            held.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1f;
            if (held.GetComponent<Rigidbody>() != null)
            {
                held.GetComponent<Rigidbody>().isKinematic = false;
                held.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 3f;
            }
            held = null;
        }
    }
}
