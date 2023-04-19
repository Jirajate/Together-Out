using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slot_Machine_1 : MonoBehaviour {

    public Renderer lcd;
    public Material black_material;
    public Material camera_material;
    public float speed = 1.25f;
    public Rigidbody2D ammo;
    public float bullet_speed = 2;
    public float firerate = 1;

    private GameObject spaceship;
    private Rigidbody2D bullet;
    private float next_fire;
    private GameObject enemy_1;
    private GameObject enemy_2;
    private GameObject enemy_3;
    private bool check = false;
    private BoxCollider2D my_col;

    // Use this for initialization
    void Start () {

        spaceship = GameObject.Find("Spaceship");
        enemy_1 = GameObject.Find("Enemy_1");
        enemy_2 = GameObject.Find("Enemy_2");
        enemy_3 = GameObject.Find("Enemy_3");
        my_col = gameObject.GetComponent<BoxCollider2D>();

    }
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal_2");

        if (Player_2_Movement.arcade_mode == 1)
        {

            lcd.material = camera_material;

            if (Player_2_Movement.enter_time + 2 < Time.time && Input.GetButtonDown("Trigger_2"))
            {
                Player_2_Movement.arcade_mode = 0;
            }
            if (horizontal < -0.5f || horizontal > 0.5f)
            {
                spaceship.transform.Translate(speed * horizontal * Time.deltaTime, 0, 0);
            }
            if (Input.GetButtonDown("Fire_1") && Time.time > next_fire)
            {
                bullet = Instantiate(ammo, new Vector3(spaceship.transform.position.x, spaceship.transform.position.y, spaceship.transform.position.z), spaceship.transform.rotation);
                bullet.velocity = transform.TransformDirection(new Vector2(0, bullet_speed));
                next_fire = Time.time + firerate;
            }
            if (enemy_1 == null && enemy_2 == null && enemy_3 == null && check == false)
            {
                check = true;
                StartCoroutine(Finishing());
                my_col.enabled = false;
                if (SceneManager.GetActiveScene().name == "TUTORIAL")
                {
                    Tutorial_Manager.hacked = true;
                }
                if (SceneManager.GetActiveScene().name == "STAGE2-1")
                {
                    Underground_Manager.hacked_1 = true;
                }
            }
        }
        else
        {
            lcd.material = black_material;
        }

    }

    IEnumerator Finishing()
    {
        yield return new WaitForSeconds(1);
        Player_2_Movement.arcade_mode = 0;
    }

}
