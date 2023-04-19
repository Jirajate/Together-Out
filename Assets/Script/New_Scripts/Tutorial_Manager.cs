using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Manager : MonoBehaviour {

    public Material white;
    public GameObject guide_1;
    public GameObject guide_2;
    public GameObject guide_3;
    public GameObject guide_4;
    public GameObject guide_5;
    public GameObject guide_6;
    public GameObject mon_1;
    public GameObject mon_2;
    public GameObject wall;
    public GameObject button;
    public GameObject slot_machine;
    public GameObject timeline;
    public GameObject cam;

    public static int clicked = 0;
    public static int died = 0;
    public static bool hacked = false;

    private float distance;
    private Renderer renderer_1;
    private Renderer renderer_2;

    private bool check_1 = false;
    private bool check_2 = false;
    private bool check_3 = false;
    private bool check_4 = false;
    private BoxCollider2D wall_col;
    

    // Use this for initialization
    void Start () {

        wall_col = wall.GetComponent<BoxCollider2D>();

        Dialogue_Manager.start_dialog = true;

        guide_1.SetActive(false);
        guide_2.SetActive(false);
        guide_3.SetActive(false);
        guide_4.SetActive(false);
        guide_5.SetActive(false);
        guide_6.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if (Dialogue_Manager.i == 11)
        {
            guide_1.SetActive(true);
            guide_2.SetActive(true);
        }
        if (Dialogue_Manager.i == 12 && clicked == 2 && !check_1)
        {
            check_1 = true;
            StartCoroutine(Finnishing_1());
        }
        if (Dialogue_Manager.i == 18)
        {
            guide_1.SetActive(false);
            guide_2.SetActive(false);
            guide_3.SetActive(true);
            guide_4.SetActive(true);
            mon_1.SetActive(true);
            mon_2.SetActive(true);
        }
        if (Dialogue_Manager.i == 32)
        {
            guide_1.SetActive(false);
            guide_2.SetActive(false);
            guide_3.SetActive(false);
            guide_4.SetActive(false);
            guide_5.SetActive(true);
            guide_6.SetActive(true);
        }
        if (Dialogue_Manager.i == 33)
        {
            wall.SetActive(true);
            button.SetActive(true);
        }
        if (Dialogue_Manager.i == 24 && died == 2 && !check_2)
        {
            check_2 = true;
            StartCoroutine(Finnishing_2());
        }
        if (Dialogue_Manager.i == 41 && clicked == 3 && !check_3)
        {
            check_3 = true;
            wall_col.enabled = false;
            StartCoroutine(Finnishing_3());
        }
        if (Dialogue_Manager.i == 49)
        {
            slot_machine.SetActive(true);
        }
        if (Dialogue_Manager.i == 51 && hacked && !check_4)
        {
            check_4 = true;
            StartCoroutine(Finnishing_4());
        }
        if (Dialogue_Manager.i == 61)
        {
            cam.GetComponent<Game_Camera>().enabled = false;
            timeline.SetActive(true);
            StartCoroutine(Next_Scene());
        }
    }

    IEnumerator Finnishing_1()
    {
        yield return new WaitForSeconds(4);
        Dialogue_Manager.start_dialog = true;
    }

    IEnumerator Finnishing_2()
    {
        yield return new WaitForSeconds(4);
        Dialogue_Manager.start_dialog = true;
    }

    IEnumerator Finnishing_3()
    {
        yield return new WaitForSeconds(4);
        Dialogue_Manager.start_dialog = true;
    }
    IEnumerator Finnishing_4()
    {
        yield return new WaitForSeconds(4);
        Dialogue_Manager.start_dialog = true;
    }
    IEnumerator Next_Scene()
    {
        yield return new WaitForSeconds(17);
        float fadeTime = GameObject.Find("Game_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Dialogue_Manager.i = 0;
        Player_1_Movement.can_move = true;
        Player_2_Movement.can_move = true;
        Player_1_Attack.can_attack = true;
        Player_2_Attack.can_attack = true;
        Dialogue_Manager.start_dialog = true;
    }

}
