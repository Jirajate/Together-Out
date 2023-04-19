using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader_Config : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = gameObject.GetComponent<Animator>();

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
        anim.SetBool("die", true);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
