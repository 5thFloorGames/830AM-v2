using UnityEngine;
using System.Collections;

public class ControlGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject startUI = GameObject.Find("StartUI");

        //GameObject inactivateThis = GameObject.Find("GamePlay");
        //inactivateThis.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Exit()
    {
        Debug.Log("Quitting application!");
        Application.Quit();
    }
}
