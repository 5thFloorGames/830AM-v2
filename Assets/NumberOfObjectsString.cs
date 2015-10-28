using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberOfObjectsString : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Text text = GetComponent<Text>();
        GameObject camera = GameObject.Find("Player_camera");
        int numChoisesToDo = camera.GetComponent<MouseLook>().numberOfChoises;

        text.text = "Go on, explore " + numChoisesToDo.ToString() + " objects.";

	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
