using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem_2 : MonoBehaviour {

    public float hp = 30f;
    public bool triggered = false;
    public Animator anim;

    public static bool totem_ready_2 = true;

    private float static_hp;

    // Use this for initialization
    void Start()
    {

        static_hp = hp;

    }

    // Update is called once per frame
    void Update()
    {

        if (hp <= 0 && !triggered)
        {
            StartCoroutine(Dying());
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Punch_Check")
        {
            hp = hp - Player_1_Attack.punch_damage;
            StartCoroutine(Hurting());
        }
        if (col.gameObject.name == "Sword_Check")
        {
            hp = hp - Player_1_Attack.sword_damage;
            StartCoroutine(Hurting());
        }
        if (col.gameObject.tag == "Bullet")
        {
            hp = hp - Player_2_Attack.bullet_damage_1;
            StartCoroutine(Hurting());
        }
        if (col.gameObject.tag == "Bullet_2")
        {
            hp = hp - Player_2_Attack.bullet_damage_2;
            StartCoroutine(Hurting());
        }
        if (col.gameObject.tag == "Bullet_3")
        {
            hp = hp - Player_2_Attack.bullet_damage_3;
            StartCoroutine(Hurting());
        }
    }

    IEnumerator Hurting()
    {
        anim.SetBool("hurt", true);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("hurt", false);
    }

    IEnumerator Dying()
    {
        triggered = true;
        yield return new WaitForSeconds(1f);
        anim.SetBool("die", true);
        totem_ready_2 = false;
        yield return new WaitForSeconds(5f);
        totem_ready_2 = true;
        yield return new WaitForSeconds(10f);
        anim.SetBool("die", false);
        hp = static_hp;
        triggered = false;
    }
}
