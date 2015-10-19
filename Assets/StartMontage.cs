using UnityEngine;
using System.Collections;

public class StartMontage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameControl = GameObject.Find("GameControl");
        ControlGame control = gameControl.GetComponent<ControlGame>();
        control.ActivateMontage();

    }

    // Update is called once per frame
    void Update () {
	
	}
}
