using UnityEngine;
using System.Collections;

public class ControlGame : MonoBehaviour {

    GameObject montage = null;

	// Use this for initialization
	void Start () {

        GameObject player_camera = GameObject.Find("Player_camera");
        FPS_translate mover = player_camera.GetComponent<FPS_translate>();
        mover.active = false;
        MouseLook rotator = player_camera.GetComponent<MouseLook>();
        rotator.active = false;


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

        GameObject startUI = GameObject.Find("StartUI");
        startUI.SetActive(false);

        montage.SetActive(true);
    }
}
