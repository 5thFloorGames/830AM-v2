using UnityEngine;
using System.Collections;

public class MontageScript : MonoBehaviour
{

    GameObject[] montageFigures;
    public float scrollTime = 3.0f;
    float timeElapsed = 0.0f;
    int pictureIndex = 0;

    // Use this for initialization
    void Start()
    {

        montageFigures = GameObject.FindGameObjectsWithTag("MontagePicture");
        for (int i = 0; i < montageFigures.Length; i++)
        {
            montageFigures[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


        timeElapsed += Time.deltaTime;

        if (timeElapsed >= scrollTime)
        {
       
            pictureIndex++;

            if (pictureIndex == montageFigures.Length)
            {
                GameObject gameControl = GameObject.Find("GameControl");
                ControlGame control = gameControl.GetComponent<ControlGame>();
                pictureIndex = 0;
                control.Reset();
            }
            timeElapsed = 0.0f;
        }

        GameObject figure = montageFigures[pictureIndex];
        NecessaryItems explorationListContainer = figure.GetComponent<NecessaryItems>();
        GameObject[] items = explorationListContainer.itemList;
        for (int i = pictureIndex; i < montageFigures.Length; i++)
        {
            
            pictureIndex = i;

            if (AnythingExplored(items))
            {
                Debug.Log(pictureIndex);
                break;
            }


            figure = montageFigures[pictureIndex];
            explorationListContainer = figure.GetComponent<NecessaryItems>();
            items = explorationListContainer.itemList;
        }

        if (pictureIndex == montageFigures.Length)
        {
            GameObject gameControl = GameObject.Find("GameControl");
            ControlGame control = gameControl.GetComponent<ControlGame>();
            pictureIndex = 0;
            control.Reset();
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


    bool AnythingExplored(GameObject[] unlockingItems)
    {
        bool explored = false;

        for (int i = 0; i < unlockingItems.Length; i++)
        {
            if (unlockingItems[i])
            {
                ExplorationReaction isExplored = unlockingItems[i].GetComponent<ExplorationReaction>();
                if (isExplored.explored)
                {
                    explored = true;
                    Debug.Log(isExplored.gameObject.name);
                }
            }
        }


        return explored;
    }
}
