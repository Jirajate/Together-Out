using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Config : MonoBehaviour {

    public float destroy_time = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, destroy_time);

	}
}
