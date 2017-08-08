using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCubeColl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Ball")
        {
            this.GetComponent<Renderer>().material.color = Collision.gameObject.GetComponent<Renderer>().material.color;
            this.GetComponent<ColorChanger>().enabled = false;
        }
    }
}
