using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Around : MonoBehaviour {

		public float speed;
	public float speed2;

    private void Start()
    {
        transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
    }
    // Update is called once per frame
    void Update () {
        if (GetComponent<_IndividualInteraction>()._BoxDisplaced){
            Transform player = GameObject.Find("CENTER").transform;
            Transform current = transform;
            transform.RotateAround(player.position, player.up, speed * Time.deltaTime);
            transform.RotateAround(current.position, current.up, speed2 * Time.deltaTime);
        }
	}
}
