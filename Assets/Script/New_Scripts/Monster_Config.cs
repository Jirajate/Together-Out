using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Config : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sword")
        {
            Tutorial_Manager.died += 1;
        }
        if (col.gameObject.tag == "Bullet")
        {
            Tutorial_Manager.died += 1;
        }
    }

}
