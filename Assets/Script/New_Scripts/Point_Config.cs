using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_Config : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col)
        {
            StartCoroutine(Destroying());
        }
    }

    IEnumerator Destroying()
    {
        Slot_Machine_2.collected = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
