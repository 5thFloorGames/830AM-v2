using UnityEngine;
using System.Collections;

public class MontageScript : MonoBehaviour {

    GameObject[] montageFigures;
    public float scrollTime = 3.0f;
    float timeElapsed = 0.0f;
    int pictureIndex = 0;

    // Use this for initialization
    void Start () {
        montageFigures = GameObject.FindGameObjectsWithTag("MontagePicture");
        for (int i = 0; i < montageFigures.Length; i++)
        {
            montageFigures[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= scrollTime)
        {
            pictureIndex = (pictureIndex + 1) % montageFigures.Length;
            timeElapsed = 0.0f;
        }

        for (int i = 0; i < montageFigures.Length; i++)
        {
            if (i == pictureIndex)
            {
                montageFigures[i].SetActive(true);
            }
            else
            {
                montageFigures[i].SetActive(false);
            }
        }


    }
}
