using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {

    void Awake()
    {

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine((Next_Scene()));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(Quitting());
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(Reloading());
        }
    }

    IEnumerator Next_Scene()
    {
        Debug.Log("Test");
        float fadeTime = GameObject.Find("Game_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Game_Camera.events = 0;
        Mid_Point.i = Game_Camera.old_i;
        Player_1_Attack.attacked = false;
        Player_1_Attack.can_attack = true;
        Player_1_Attack.can_swing = true;
        Player_2_Movement.can_move = true;
        Player_2_Attack.can_attack = true;
        Player_2_Movement.arcade_mode = 0;
        Player_2_Movement.arcade_mode = 0;
        Player_2_Movement.arcade_check = true;
        Player_2_Movement.enter_time = 1000000;
        Slot_Machine_2.collected = false;
    }

    IEnumerator Quitting()
    {
        float fadeTime = GameObject.Find("Game_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();
    }

    IEnumerator Reloading()
    {
        float fadeTime = GameObject.Find("Game_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Game_Camera.events = 0;
        Mid_Point.i = Game_Camera.old_i;
        Player_1_Attack.attacked = false;
        Player_1_Attack.can_attack = true;
        Player_1_Attack.can_swing = true;
        Player_2_Movement.can_move = true;
        Player_2_Attack.can_attack = true;
        Player_2_Movement.arcade_mode = 0;
        Player_2_Movement.arcade_mode = 0;
        Player_2_Movement.arcade_check = true;
        Player_2_Movement.enter_time = 1000000;
        Slot_Machine_2.collected = false;
    }

}
