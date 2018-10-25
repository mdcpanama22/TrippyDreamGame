using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornGirlFlicker : MonoBehaviour {

    SpriteRenderer sprite;

    float r, g, b;

    bool visible = true;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        r = 1f;
        g = 1f;
        b = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (visible)
        {
            sprite.enabled = false;
            visible = false;
        } else
        {
            sprite.enabled = true;

            r += Random.Range(-0.05f, 0.05f);
            r = Mathf.Clamp(r, 0.7f, 1f);
            g += Random.Range(-0.05f, 0.05f);
            g = Mathf.Clamp(g, 0.7f, 1f);
            b += Random.Range(-0.05f, 0.05f);
            b = Mathf.Clamp(b, 0.7f, 1f);

            Color newColor = new Color(r, g, b);
            sprite.color = newColor;

            visible = true;
        }
	}
}
