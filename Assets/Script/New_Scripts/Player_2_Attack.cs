using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Attack : MonoBehaviour
{

    public Animator anim;
    public float firerate_1 = 0.75f;
    public float bullet_speed = 7f;
    public Rigidbody2D ammo_1;
    public Rigidbody2D ammo_2;
    public Rigidbody2D ammo_3;
    public Rigidbody2D wall;
    public float cooldown = 5f;
    public static float bullet_damage_1 = 2f;
    public static float bullet_damage_2 = 6f;
    public static float bullet_damage_3 = 10f;
    public static int type = 1;
    public static int skill = 0;

    private bool facing_right;
    private float nextfire;
    private Rigidbody2D bullet;
    private bool can_defend = true;
    private Vector3 ammo_scale_1;
    private Vector3 ammo_scale_2;
    private Vector3 ammo_scale_3;
    private AudioSource[] audi;

    public static bool shield_ready = true;
    public static bool can_attack = true;

    // Use this for initialization
    void Start()
    {

        ammo_scale_1 = ammo_1.transform.localScale;
        ammo_scale_2 = ammo_2.transform.localScale;
        ammo_scale_3 = ammo_3.transform.localScale;
        audi = gameObject.GetComponents<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        facing_right = Player_2_Movement.facing_right;

        if (Input.GetButton("Fire_1") && Time.time > nextfire && can_attack)
        {
            anim.SetBool("drink", false);
            Player_2_Movement.can_move = false;
            anim.SetBool("attack", true);
        }
        else if (Input.GetButtonUp("Fire_1") && Time.time > nextfire && can_attack)
        {
            Attacking();
        }

        else if (Input.GetButtonDown("Fire_2") && can_attack)
        {
            if (skill == 0 && can_defend)
            {
                Player_2_Movement.can_move = false;
                StartCoroutine(Defending());
            }
            else if (skill == 1 && can_defend)
            {
                Player_2_Movement.can_move = false;
                StartCoroutine(Faning());
            }
        }

    }

    void Attacking()
    {
        anim.SetBool("attack", false);
        Player_2_Movement.can_move = true;
        if (type == 1)
        {
            nextfire = Time.time + firerate_1;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Lattack-1"))
            {
                audi[1].pitch = Random.Range(0.95f, 1);
                audi[1].volume = Random.Range(0.7f, 1);
                audi[1].Play();
                if (facing_right)
                {
                    bullet = Instantiate(ammo_1, new Vector3(transform.position.x + 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.transform.localScale = new Vector3(-ammo_scale_1.x, ammo_scale_1.y, ammo_scale_1.z);
                    bullet.velocity = transform.TransformDirection(new Vector2(bullet_speed, 0));
                }
                else
                {
                    bullet = Instantiate(ammo_1, new Vector3(transform.position.x - 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector2(-bullet_speed, 0));
                }
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Lattack-2"))
            {
                audi[1].pitch = Random.Range(0.95f, 1);
                audi[1].volume = Random.Range(0.7f, 1);
                audi[1].Play();
                if (facing_right)
                {
                    bullet = Instantiate(ammo_2, new Vector3(transform.position.x + 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.transform.localScale = new Vector3(-ammo_scale_2.x, ammo_scale_2.y, ammo_scale_2.z);
                    bullet.velocity = transform.TransformDirection(new Vector2(bullet_speed, 0));
                }
                else
                {
                    bullet = Instantiate(ammo_2, new Vector3(transform.position.x - 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector2(-bullet_speed, 0));
                }
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Lattack-3"))
            {
                audi[1].pitch = Random.Range(0.95f, 1);
                audi[1].volume = Random.Range(0.7f, 1);
                audi[1].Play();
                if (facing_right)
                {
                    bullet = Instantiate(ammo_3, new Vector3(transform.position.x + 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.transform.localScale = new Vector3(-ammo_scale_3.x, ammo_scale_3.y, ammo_scale_3.z);
                    bullet.velocity = transform.TransformDirection(new Vector2(bullet_speed, 0));
                }
                else
                {
                    bullet = Instantiate(ammo_3, new Vector3(transform.position.x - 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector2(-bullet_speed, 0));
                }
            }
        }
        else if (type == 2)
        {
            nextfire = Time.time + firerate_1;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Lattack-1"))
            {
                audi[1].pitch = Random.Range(0.95f, 1);
                audi[1].volume = Random.Range(0.7f, 1);
                audi[1].Play();
                if (facing_right)
                {
                    bullet = Instantiate(ammo_1, new Vector3(transform.position.x + 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector2(bullet_speed, 0.3f));
                }
                else
                {
                    bullet = Instantiate(ammo_1, new Vector3(transform.position.x - 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector2(-bullet_speed, 0.3f));
                }
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Lattack-2"))
            {
                audi[1].pitch = Random.Range(0.95f, 1);
                audi[1].volume = Random.Range(0.7f, 1);
                audi[1].Play();
                if (facing_right)
                {
                    bullet = Instantiate(ammo_2, new Vector3(transform.position.x + 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector2(bullet_speed, 0.3f));
                }
                else
                {
                    bullet = Instantiate(ammo_2, new Vector3(transform.position.x - 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector2(-bullet_speed, 0.3f));
                }
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Lattack-3"))
            {
                audi[1].pitch = Random.Range(0.95f, 1);
                audi[1].volume = Random.Range(0.7f, 1);
                audi[1].Play();
                if (facing_right)
                {
                    bullet = Instantiate(ammo_3, new Vector3(transform.position.x + 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector2(bullet_speed, 0.3f));
                }
                else
                {
                    bullet = Instantiate(ammo_3, new Vector3(transform.position.x - 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                    bullet.velocity = transform.TransformDirection(new Vector2(-bullet_speed, 0.3f));
                }
            }
        }
    }

    IEnumerator Defending()
    {
        audi[2].Play();
        can_defend = false;
        anim.SetBool("defend", true);
        shield_ready = false;
        if (facing_right)
        {
            Instantiate(wall, new Vector3(transform.position.x + 1.5f, transform.position.y - 2f, transform.position.z), transform.rotation);
        }
        else if (!facing_right)
        {
            Instantiate(wall, new Vector3(transform.position.x - 1.5f, transform.position.y - 2f, transform.position.z), transform.rotation);
        }
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("defend", false);
        Player_2_Movement.can_move = true;
        yield return new WaitForSeconds(cooldown);
        shield_ready = true;
        can_defend = true;
    }

    IEnumerator Faning()
    {
        can_defend = false;
        shield_ready = false;
        anim.SetBool("attack", true);
        for (int i = 0; i < 3; i++)
        {
            if (facing_right)
            {
                audi[1].pitch = Random.Range(0.95f, 1);
                audi[1].volume = Random.Range(0.7f, 1);
                audi[1].Play();
                bullet = Instantiate(ammo_1, new Vector3(transform.position.x + 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                bullet.transform.localScale = new Vector3(-ammo_scale_1.x, ammo_scale_1.y, ammo_scale_1.z);
                bullet.velocity = transform.TransformDirection(new Vector2(bullet_speed, 0));
            }
            else
            {
                bullet = Instantiate(ammo_1, new Vector3(transform.position.x - 1.2f, transform.position.y - 2f, transform.position.z), transform.rotation);
                bullet.velocity = transform.TransformDirection(new Vector2(-bullet_speed, 0));
            }
            yield return new WaitForSeconds(0.2f);
        }
        anim.SetBool("attack", false);
        Player_2_Movement.can_move = true;
        yield return new WaitForSeconds(cooldown);
        can_defend = true;
        shield_ready = true;
    }

}
