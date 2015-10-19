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

            if (pictureIndex + 1 == montageFigures.Length)
            {
                GameObject gameControl = GameObject.Find("GameControl");
                ControlGame control = gameControl.GetComponent<ControlGame>();
                control.Reset();
            }

            pictureIndex = (pictureIndex + 1) % montageFigures.Length;
            timeElapsed = 0.0f;
        }

        GameObject figure = montageFigures[pictureIndex];
        NecessaryItems explorationListContainer = figure.GetComponent<NecessaryItems>();
        GameObject[] items = explorationListContainer.itemList;
        while (!EverythingExplored(items))
        {

            if (pictureIndex + 1 == montageFigures.Length)
            {
                GameObject gameControl = GameObject.Find("GameControl");
                ControlGame control = gameControl.GetComponent<ControlGame>();
                control.Reset();
            }

            pictureIndex = (pictureIndex + 1) % montageFigures.Length;

            figure = montageFigures[pictureIndex];
            explorationListContainer = figure.GetComponent<NecessaryItems>();
            items = explorationListContainer.itemList;
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


    bool EverythingExplored(GameObject[] unlockingItems)
    {
        bool explored = true;

        for (int i = 0; i < unlockingItems.Length; i++)
        {
            if (unlockingItems[i])
            {
                Debug.Log(unlockingItems[i].name);
                ExplorationReaction isExplored = unlockingItems[i].GetComponent<ExplorationReaction>();
                if (!(isExplored.explored))
                {
                    explored = false;
                }
            }
        }

        return explored;
    }
}
