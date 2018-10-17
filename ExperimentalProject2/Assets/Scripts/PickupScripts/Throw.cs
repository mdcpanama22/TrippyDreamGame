using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    public void Use(GameObject player)
    {
        player.GetComponent<Pickup>().Drop();
        Vector3 direction = Camera.main.transform.forward;
        direction *= 15f;
        direction += Vector3.up * 3f;
        GetComponent<Rigidbody>().velocity = direction;
    }
}
