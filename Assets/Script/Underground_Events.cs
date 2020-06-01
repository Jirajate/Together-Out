using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underground_Events : MonoBehaviour {

    public GameObject wave_1;
    public GameObject wave_2;
    public GameObject wave_3;
    public GameObject wave_4;

    // Use this for initialization
    void Start () {

        wave_1.SetActive(false);
        wave_2.SetActive(false);
        wave_3.SetActive(false);
        wave_4.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Player_2")
        {
            if (Input.GetButtonDown("Trigger_2"))
            {
                StartCoroutine(Next_Wave());
            }
        }
    }

    IEnumerator Next_Wave()
    {
        yield return new WaitForSeconds(5f);
        wave_1.SetActive(true);
        yield return new WaitForSeconds(5f);
        wave_2.SetActive(true);
        yield return new WaitForSeconds(5f);
        wave_3.SetActive(true);
        yield return new WaitForSeconds(5f);
        wave_4.SetActive(true);
    }

}
