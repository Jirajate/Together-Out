using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underground_Button_1 : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {

        anim.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetButtonDown("Trigger_1"))
        {
            anim.enabled = true;
        }
    }

}
