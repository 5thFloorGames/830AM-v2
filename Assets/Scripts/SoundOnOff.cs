using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundOnOff : MonoBehaviour {

    public bool inEffectZone = false;

    void OnTriggerEnter(Collider other)
    {

        GameObject userInterface = GameObject.Find("Instruction");
        userInterface.GetComponent<Text>().text = "Press left mouse button.";

        inEffectZone = true;
    }

    void OnTriggerExit(Collider other)
    {

        GameObject userInterface = GameObject.Find("Instruction");
        userInterface.GetComponent<Text>().text = "Go back to Mona Lisa. It was not nice leaving her.";

        inEffectZone = false;
        AudioSource audio = GetComponent<AudioSource>();
        audio.Stop();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (inEffectZone)
        {

            if (Input.GetButtonDown("Fire1"))
            {

                GameObject userInterface = GameObject.Find("Instruction");
                userInterface.GetComponent<Text>().text = "LOL";

                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }

        }
	}
}
