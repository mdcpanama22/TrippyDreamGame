using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Around : MonoBehaviour {

		public float speed;
	public float speed2;

    private void Start()
    {
        transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        InvokeRepeating("ChangeSpeed", 1.0f, 5.0f);
    }
    void ChangeSpeed()
    {
        speed = Random.Range(-120f, 120);
        speed2 = Random.Range(-80f, 80);
    }
    // Update is called once per frame
    void Update () {
        if (GetComponent<_IndividualInteraction>()._BoxDisplaced){
            Transform current = transform;
            transform.RotateAround(new Vector3(0f,0f,0f), Vector3.up, speed * Time.deltaTime);
            transform.RotateAround(current.position, current.up, speed2 * Time.deltaTime);
        }
	}
}
