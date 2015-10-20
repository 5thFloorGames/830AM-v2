using UnityEngine;
using System.Collections;

public class ControlGame : MonoBehaviour {

    GameObject startUI = null;
    GameObject gamePlay = null;
    GameObject montage = null;
    Transform cameraInit = null;
    GameObject clock = null;

	// Use this for initialization
	void Start () {

        startUI = GameObject.Find("StartUI");
        startUI.SetActive(true);
        gamePlay = GameObject.Find("GamePlay");

        GameObject player_camera = GameObject.Find("Player_camera");
        FPS_translate mover = player_camera.GetComponent<FPS_translate>();
        mover.active = false;
        MouseLook rotator = player_camera.GetComponent<MouseLook>();
        rotator.active = false;

        clock = GameObject.Find("Clock");
        clock.SetActive(false);

        //gamePlay.SetActive(false);

        montage = GameObject.Find("Montage");
        montage.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Exit()
    {
        Debug.Log("Quitting application!");
        Application.Quit();
    }

    public void ActivateGame()
    {


        GameObject player_camera = GameObject.Find("Player_camera");
        FPS_translate mover = player_camera.GetComponent<FPS_translate>();
        mover.active = true;
        MouseLook rotator = player_camera.GetComponent<MouseLook>();
        rotator.active = true;


        startUI.SetActive(false);
        gamePlay.SetActive(true);
        montage.SetActive(false);
        clock.SetActive(true);
        UnityEngine.Cursor.visible = false;


    }

    public void ActivateMontage()
    {
        startUI.SetActive(false);
        gamePlay.SetActive(false);
        montage.SetActive(true);
    }

    public void Reset()
    {
        startUI.SetActive(true);
        gamePlay.SetActive(true);
        montage.SetActive(true);
        UnityEngine.Cursor.visible = true;


        GameObject[] objects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        for (int i = 0; i < objects.Length; i++)
        {
            ExplorationReaction reaction = objects[i].GetComponent<ExplorationReaction>();
            if (reaction)
            {
                reaction.explored = false;
            }
        }

        GameObject player_camera = GameObject.Find("Player_camera");
        FPS_translate mover = player_camera.GetComponent<FPS_translate>();
        mover.active = false;
        MouseLook rotator = player_camera.GetComponent<MouseLook>();
        rotator.active = false;
        Debug.Log(player_camera.transform.rotation);

        startUI.SetActive(true);
        gamePlay.SetActive(false);
        montage.SetActive(false);

    }
}
