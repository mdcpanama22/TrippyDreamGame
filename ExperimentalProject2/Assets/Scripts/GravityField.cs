using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour {

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpSpeed = 10f;
    public float gravityMultiplier = 2f;


    bool triggered = false;
    GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RealFPSController")
        {
            player = other.gameObject;
            triggered = true;
            player.SendMessage("SetWalkSpeed", walkSpeed);
            player.SendMessage("SetRunSpeed", runSpeed);
            player.SendMessage("SetJumpSpeed", jumpSpeed);
            player.SendMessage("SetGravityMultiplier", gravityMultiplier);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "RealFPSController")
        {
            triggered = false;
            player.SendMessage("ResetValues");
        }
    }
}
