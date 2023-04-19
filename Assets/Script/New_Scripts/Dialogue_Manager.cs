using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue_Manager : MonoBehaviour {

    // public float text_speed = 0.01f;
    [TextArea(3,10)]
    public string[] sentences;

    public static int i = 0;
    public static bool start_dialog = true;

    private int max_i;
    private Text text_area;
    private GameObject background;
    private GameObject may;
    private GameObject june;
    private GameObject mita;

    // Use this for initialization
    void Start () {

        text_area = GameObject.Find("Text").GetComponent<Text>();
        background = GameObject.Find("Dialogue");
        may = GameObject.Find("MAY_Portrait");
        june = GameObject.Find("JUNE_Portrait");
        mita = GameObject.Find("MITA_Portrait");

        max_i = sentences.Length;
        background.SetActive(false);
        may.SetActive(false);
        june.SetActive(false);
        mita.SetActive(false);

        Invoke("Next_Dialogue", 1);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (SceneManager.GetActiveScene().name == "TUTORIAL")
            {
                i = 51;
                start_dialog = true;
            }
            if (SceneManager.GetActiveScene().name == "STAGE1")
            {
                i = 31;
                start_dialog = true;
            }
        }

        if (start_dialog)
        {
            Player_1_Movement.can_move = false;
            Player_1_Attack.can_attack = false;
            Player_2_Movement.can_move = false;
            Player_2_Attack.can_attack = false;
        }

        if (start_dialog && (Input.GetButtonDown("Jump_1") || Input.GetButtonDown("Jump_2")))
        {
            background.SetActive(false);
            may.SetActive(false);
            june.SetActive(false);
            mita.SetActive(false);
            if (SceneManager.GetActiveScene().name == "TUTORIAL")
            {
                if (i == 11)
                {
                    text_area.text = "";
                    background.SetActive(false);
                    start_dialog = false;
                    Player_1_Movement.can_move = true;
                    Player_1_Attack.can_attack = true;
                    Player_2_Movement.can_move = true;
                    Player_2_Attack.can_attack = true;
                    i++;
                }
                else if (i == 23)
                {
                    text_area.text = "";
                    background.SetActive(false);
                    start_dialog = false;
                    Player_1_Movement.can_move = true;
                    Player_1_Attack.can_attack = true;
                    Player_2_Movement.can_move = true;
                    Player_2_Attack.can_attack = true;
                    i++;
                }
                else if (i == 40)
                {
                    text_area.text = "";
                    background.SetActive(false);
                    start_dialog = false;
                    Player_1_Movement.can_move = true;
                    Player_1_Attack.can_attack = true;
                    Player_2_Movement.can_move = true;
                    Player_2_Attack.can_attack = true;
                    i++;
                }
                else if (i == 50)
                {
                    text_area.text = "";
                    background.SetActive(false);
                    start_dialog = false;
                    Player_1_Movement.can_move = true;
                    Player_1_Attack.can_attack = true;
                    Player_2_Movement.can_move = true;
                    Player_2_Attack.can_attack = true;
                    i++;
                }
                else if (i == 60)
                {
                    text_area.text = "";
                    background.SetActive(false);
                    start_dialog = false;
                    i++;
                }
                else
                {
                    Next_Dialogue();
                }
            }
            if (SceneManager.GetActiveScene().name == "STAGE1")
            {
                Next_Dialogue();
            }
        }

        if (SceneManager.GetActiveScene().name == "TUTORIAL")
        {
            if (i == 12 && start_dialog)
            {
                Next_Dialogue();
            }
            if (i == 24 && start_dialog)
            {
                Next_Dialogue();
            }
            if (i == 41 && start_dialog)
            {
                Next_Dialogue();
            }
            if (i == 51 && start_dialog)
            {
                Next_Dialogue();
            }
        }
    }

    public void Next_Dialogue()
    {
        if (i < max_i)
        {
            background.SetActive(true);
            text_area.text = sentences[i];
            i++;
            if (SceneManager.GetActiveScene().name == "TUTORIAL")
            {
                if (i == 1 || i == 3 || i == 6 || i == 7 || i == 10 || i == 14 || i == 18 || i == 19 || i == 23 || i == 26 || i == 28 || i == 31 || i == 33 || i == 35 || i == 37 || i == 40 || i == 43 || i == 49 || i == 53 || i == 60 || i == 61)
                {
                    may.SetActive(true);
                }
                if (i == 2 || i == 9 || i == 15 || i == 20 || i == 22 || i == 27 || i == 29 || i == 15 || i == 20 || i == 22 || i == 27 || i == 29 || i == 36 || i == 39 || i == 44 || i == 48 || i == 54 || i == 57)
                {
                    june.SetActive(true);
                }
                if (i == 4 || i == 5 || i == 8 || i == 11 || i == 13 || i == 16 || i == 17 || i == 21 || i == 25 || i == 30 || i == 32 || i == 34 || i == 38 || i == 42 || i == 45 || i == 46 || i == 47 || i == 50 || i == 52 || i == 55 || i == 56 || i == 58 || i == 59)
                {
                    mita.SetActive(true);
                }
            }
            if (SceneManager.GetActiveScene().name == "STAGE1")
            {
                if (i == 1 || i == 3 || i == 6 || i == 8 || i == 11 || i == 12 || i == 14 || i == 15 || i == 16 || i == 17|| i == 19 || i == 20 || i == 21 || i == 25 || i == 26 || i == 28 || i == 30 || i == 31)
                {
                    may.SetActive(true);
                }
                if (i == 4 || i == 9 || i == 10 || i == 13 || i == 18 || i == 22 || i == 23 || i == 24 || i == 27)
                {
                    june.SetActive(true);
                }
                if (i == 2 || i == 5 || i == 7 || i == 29 || i == 32)
                {
                    mita.SetActive(true);
                }
            }
        }
        else
        {
            text_area.text = "";
            background.SetActive(false);
            start_dialog = false;
            Player_1_Movement.can_move = true;
            Player_1_Attack.can_attack = true;
            Player_2_Movement.can_move = true;
            Player_2_Attack.can_attack = true;
        }
    }

    //IEnumerator Next_Dialogue()
    //{
    //    if (i < max_i)
    //    {
    //        Debug.Log("test_1");
    //        text_area.text = "";
    //        foreach (char letter in sentences[i])
    //        {
    //            Debug.Log("test_2");
    //            text_area.text += letter;
    //            yield return new WaitForSeconds(text_speed);
    //        }
    //        i++;
    //    }
    //    else
    //    {
    //        Debug.Log("test_3");
    //        text_area.text = "";
    //    }
    //}

}
