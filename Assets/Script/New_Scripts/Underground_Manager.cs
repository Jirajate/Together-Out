using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underground_Manager : MonoBehaviour {

    public GameObject door_1;
    public Rigidbody2D door_2;
    public float power = 300;
    public float max_speed = 1;

    public static bool hacked_1 = false;
    public static bool hacked_2 = false;

    private Animator anim_1;
    private BoxCollider2D col_1;

	// Use this for initialization
	void Start () {

        anim_1 = door_1.GetComponent<Animator>();
        col_1 = door_1.GetComponent<BoxCollider2D>();

        anim_1.enabled = false;
        col_1.enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (hacked_1)
        {
            anim_1.enabled = true;
            col_1.enabled = false;
        }

        if(hacked_2)
        {
            door_2.AddForce(Vector2.up * power);
            if (door_2.velocity.y > max_speed)
            {
                door_2.velocity = new Vector2(0, max_speed);
            }
        }

	}
}
