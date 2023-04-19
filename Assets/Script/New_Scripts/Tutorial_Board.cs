using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Board : MonoBehaviour {

    public Transform target_position;
    private LineRenderer myLine;

	// Use this for initialization
	void Start () {

        myLine = gameObject.GetComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {

        myLine.SetPosition(0, new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z));
        myLine.SetPosition(1, new Vector3(target_position.position.x, target_position.position.y - 2f, target_position.position.z));

    }
}
