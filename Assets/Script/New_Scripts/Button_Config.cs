using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Config : MonoBehaviour {

    private BoxCollider2D my_col;
    private Rigidbody2D my_rigid;

	// Use this for initialization
	void Start () {

        my_col = gameObject.GetComponent<BoxCollider2D>();
        my_rigid = gameObject.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Player_1")
        {
            if (Input.GetButtonDown("Trigger_1"))
            {
                Tutorial_Manager.clicked += 1;
                my_col.enabled = false;
                my_rigid.gravityScale = 1;
            }
        }
        if (col.gameObject.name == "Player_2")
        {
            if (Input.GetButtonDown("Trigger_2"))
            {
                Tutorial_Manager.clicked += 1;
                my_col.enabled = false;
                my_rigid.gravityScale = 1;
            }
        }
    }

}
