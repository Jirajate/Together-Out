using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Attack : MonoBehaviour
{

    public Animator anim;
    public static bool attacked = false;
    public int combo = 0;
    public float delay = 0.2f;
    private float timing;
    public bool punching;
    public Collider2D sword;
    public Collider2D punch;
    public static float punch_damage = 2f;
    public static float sword_damage = 10f;
    public float cooldown = 5f;

    public static bool can_attack = true;
    public static bool sword_ready = true;
    public static bool can_punch = true;
    public static bool can_swing = true;

    private AudioSource[] audi;
    private bool is_hurt;

    // Use this for initialization
    void Start()
    {

        sword.enabled = false;
        punch.enabled = false;

        audi = gameObject.GetComponents<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        is_hurt = anim.GetCurrentAnimatorStateInfo(0).IsName("Rhurt");

        if (Input.GetKeyDown(KeyCode.H) || Input.GetButtonDown("Cheat"))
        {
            can_attack = true;
            attacked = false;
            can_swing = true;
        }

        if (Input.GetButton("Swing") && !attacked && can_attack && can_swing && !is_hurt)
        {
            anim.SetBool("drink", false);
            StartCoroutine(Attacking());
        }

        if (Input.GetButtonDown("Punch") && can_punch && can_attack && !is_hurt)
        {
            anim.SetBool("drink", false);
            if (combo == 0 && !punching)
            {
                StartCoroutine(Punch_1());
                timing = Time.time + 1;
            }
            else if (combo == 1 && Time.time < timing && !punching && can_attack && !is_hurt)
            {
                StartCoroutine(Punch_2());
                timing = Time.time + 1;
            }

            else if (combo == 2 && Time.time < timing && !punching && can_attack && !is_hurt)
            {
                StartCoroutine(Punch_3());
                timing = Time.time + 1;
            }
        }

        if (Time.time > timing)
        {
            combo = 0;
            anim.SetBool("punch", false);
            anim.SetInteger("combo", 0);
        }

    }

    IEnumerator Attacking()
    {
        audi[2].Play();
        Player_1_Movement.can_move = false;
        Player_1_Movement.immue = true;
        attacked = true;
        can_swing = false;
        anim.SetBool("attack", true);
        sword.enabled = true;
        sword_ready = false;
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("attack", false);
        sword.enabled = false;
        attacked = false;
        Player_1_Movement.can_move = true;
        Player_1_Movement.immue = false;
        yield return new WaitForSeconds(cooldown);
        can_swing = true;
        sword_ready = true;
    }

    IEnumerator Punch_1()
    {
        Player_1_Movement.can_move = false;
        audi[1].Play();
        anim.SetBool("punch", true);
        punch.enabled = true;
        punching = true;
        Player_1_Movement.immue = true;
        yield return new WaitForSeconds(delay);
        Player_1_Movement.can_move = true;
        punching = false;
        anim.SetBool("punch", false);
        anim.SetInteger("combo", 1);
        punch.enabled = false;
        Player_1_Movement.immue = false;
        combo = 1;
    }

    IEnumerator Punch_2()
    {
        Player_1_Movement.can_move = false;
        audi[1].Play();
        anim.SetBool("punch", true);
        punch.enabled = true;
        punching = true;
        Player_1_Movement.immue = true;
        yield return new WaitForSeconds(delay);
        Player_1_Movement.can_move = true;
        punching = false;
        anim.SetBool("punch", false);
        anim.SetInteger("combo", 2);
        punch.enabled = false;
        Player_1_Movement.immue = false;
        combo = 2;
    }

    IEnumerator Punch_3()
    {
        Player_1_Movement.can_move = false;
        audi[1].Play();
        anim.SetBool("punch", true);
        punch.enabled = true;
        punching = true;
        Player_Movement_1.immue = true;
        yield return new WaitForSeconds(delay);
        Player_1_Movement.can_move = true;
        punching = false;
        anim.SetBool("punch", false);
        anim.SetInteger("combo", 0);
        punch.enabled = false;
        Player_1_Movement.immue = false;
        combo = 0;
    }

}
