using UnityEngine;
using System.Collections;

public class ControlGame : MonoBehaviour
{

    GameObject startUI = null;
    GameObject gamePlay = null;
    GameObject montage = null;
    GameObject gamePlaySound = null;
    GameObject footStepSound = null;
    ExplorationReaction[] exploratives = null;

    Vector3 cameraInit = new Vector3(0.0f, 0.0f, 0.0f);
    Quaternion cameraInitRotation = new Quaternion();

    //int initHours = 0;
    //int initMinutes = 0;
    //int initExtraTime = 0;

    bool paused = false;

    GameObject clock = null;

    // Use this for initialization
    void Start()
    {

        exploratives = FindObjectsOfType<ExplorationReaction>();

        startUI = GameObject.Find("StartUI");
        startUI.SetActive(true);
        gamePlay = GameObject.Find("GamePlay");
        gamePlaySound = GameObject.Find("GamePlaySounds");
        footStepSound = GameObject.Find("FootstepSounds");

        GameObject player_camera = GameObject.Find("Player_camera");
        FPS_translate mover = player_camera.GetComponent<FPS_translate>();
        mover.active = false;
        MouseLook rotator = player_camera.GetComponent<MouseLook>();
        rotator.active = false;
        cameraInitRotation = player_camera.transform.rotation;

        cameraInit = player_camera.transform.position;

        clock = GameObject.Find("Clock");
        clock.SetActive(false);

        //initMinutes = clock.GetComponent<RunningTime>().minutes;
        //initHours = clock.GetComponent<RunningTime>().hours;
        //initExtraTime = clock.GetComponent<RunningTime>().extraTime;

        if (gamePlaySound)
        {
            gamePlaySound.SetActive(false);
        }

        if (footStepSound)
        {
            footStepSound.SetActive(false);
        }

        //gamePlay.SetActive(false);



        montage = GameObject.Find("Montage");
        montage.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Pause_Unpause();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Reset();
        }
    }

    public void Exit()
    {
        Debug.Log("Quitting application!");
        Application.Quit();
    }

    public void ActivateGame()
    {

        if (gamePlaySound)
        {
            gamePlaySound.SetActive(true);
        }

        if (footStepSound)
        {
            footStepSound.SetActive(true);
        }

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

        if (footStepSound)
        {
            footStepSound.SetActive(false);
        }

        if (gamePlaySound)
        {
            gamePlaySound.SetActive(false);
        }
        startUI.SetActive(false);
        gamePlay.SetActive(false);
        montage.SetActive(true);
    }

    public void Pause_Unpause()
    {

        if (!paused)
        {
            clock.SetActive(false);
            GameObject player_camera = GameObject.Find("Player_camera");
            FPS_translate mover = player_camera.GetComponent<FPS_translate>();
            mover.active = false;
            MouseLook rotator = player_camera.GetComponent<MouseLook>();
            rotator.active = false;
            cameraInitRotation = player_camera.transform.rotation;
            paused = true;
            if (gamePlaySound)
            {
                gamePlaySound.SetActive(false);
            }
            if (footStepSound)
            {
                footStepSound.SetActive(false);
            }
        }
        else
        {
            if (gamePlaySound)
            {
                gamePlaySound.SetActive(true);
            }
            if (footStepSound)
            {
                footStepSound.SetActive(true);
            }
            clock.SetActive(true);
            GameObject player_camera = GameObject.Find("Player_camera");
            FPS_translate mover = player_camera.GetComponent<FPS_translate>();
            mover.active = true;
            MouseLook rotator = player_camera.GetComponent<MouseLook>();
            rotator.active = true;
            cameraInitRotation = player_camera.transform.rotation;
            paused = false;
        }
    }

    public void Reset()
    {
        if (gamePlaySound)
        {
            gamePlaySound.SetActive(false);
        }
        if (footStepSound)
        {
            footStepSound.SetActive(false);
        }
        startUI.SetActive(true);
        gamePlay.SetActive(true);
        montage.SetActive(true);
        UnityEngine.Cursor.visible = true;


        GameObject camera = GameObject.Find("Player_camera");
        camera.GetComponent<MouseLook>().choisesDone = 0;

        foreach (ExplorationReaction reaction in exploratives)
        {
            reaction.explored = false;
        }

        //for (int i = 0; i < objects.Length; i++)
        //{
        //    ExplorationReaction reaction = objects[i].GetComponent<ExplorationReaction>();
        //    if (reaction)
        //    {
        //        if (reaction.explored)
        //        {
        //            Debug.Log(objects[i].name);
        //        }
        //        objects[i].GetComponent<ExplorationReaction>().explored = false;
        //    }
        //}

        GameObject player_camera = GameObject.Find("Player_camera");
        FPS_translate mover = player_camera.GetComponent<FPS_translate>();
        mover.active = false;
        MouseLook rotator = player_camera.GetComponent<MouseLook>();
        rotator.active = false;

        player_camera.transform.position = cameraInit;
        player_camera.transform.rotation = cameraInitRotation;

        //clock.GetComponent<RunningTime>().minutes = initMinutes;
        //clock.GetComponent<RunningTime>().hours = initHours;
        //clock.GetComponent<RunningTime>().extraTime = initExtraTime;

        startUI.SetActive(true);
        gamePlay.SetActive(true);
        clock.SetActive(false);
        montage.SetActive(false);

    }
}
