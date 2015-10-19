using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour
{


    void OnGUI()
    {
        Debug.Log("Now quitting application!");
        Application.Quit();
    }


}


