using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slot_Machine_2 : MonoBehaviour {

    public Renderer lcd_1;
    public Renderer lcd_2;
    public Renderer lcd_3;
    public Material black_material;
    public Material camera_material;
    public float speed = 1.25f;

    public static bool collected = false;

    private bool check = false;
    private GameObject pac_man;
    private BoxCollider2D my_col;

    // Use this for initialization
    void Start () {

        pac_man = GameObject.Find("Pac_Man");
        my_col = gameObject.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal_2");
        float vertical = Input.GetAxis("Vertical_2");

        if (Player_2_Movement.arcade_mode == 2)
        {
            if (Player_2_Movement.enter_time + 2 < Time.time && Input.GetButtonDown("Trigger_2"))
            {
                Player_2_Movement.arcade_mode = 0;
            }
            lcd_1.material = camera_material;
            lcd_2.material = camera_material;
            lcd_3.material = camera_material;
            if (horizontal < -0.5f || horizontal > 0.5f)
            {
                pac_man.transform.Translate(speed * horizontal * Time.deltaTime, 0, 0);
            }
            if (vertical < -0.5f || vertical > 0.5f)
            {
                pac_man.transform.Translate(0, speed * vertical * Time.deltaTime, 0);
            }
            if (collected && !check)
            {
                check = true;
                StartCoroutine(Finishing());
                my_col.enabled = false;
            }
            //if (check == false)
            //{
            //    check = true;
            //    StartCoroutine(Finishing());
            //}
        }
        else
        {
            lcd_1.material = black_material;
            lcd_2.material = black_material;
            lcd_3.material = black_material;
        }
    }

    IEnumerator Finishing()
    {
        yield return new WaitForSeconds(1);
        Player_2_Movement.arcade_mode = 0;
        if(SceneManager.GetActiveScene().name == "STAGE2-1")
        {
            Underground_Manager.hacked_2 = true;
        }
    }

}
