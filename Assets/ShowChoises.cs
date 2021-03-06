﻿using UnityEngine;
using System.Collections;

public class ShowChoises : MonoBehaviour
{

    TextMesh[] choises = null;
    public float disappearTime = 3.0f;
    float timeCount = 0.0f;

    // Use this for initialization
    void Start()
    {

        choises = gameObject.GetComponentsInChildren<TextMesh>();

        foreach (TextMesh choise in choises)
        {
            choise.gameObject.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {

        ExplorationReaction exploration = GetComponent<ExplorationReaction>();

        bool someChoisePicked = false;

        foreach (TextMesh choise in choises)
        {
            ExplorationReaction childExploration = choise.gameObject.GetComponent<ExplorationReaction>();
            if (childExploration)
            {
                if (childExploration.explored)
                {
                    someChoisePicked = true;
                }
            }
        }


        if (exploration.explored && !someChoisePicked)
        {

            foreach (TextMesh choise in choises)
            {
                choise.gameObject.SetActive(true);
            }
        }

        if (exploration.explored && someChoisePicked)
        {
            AudioSource audio = GetComponent<AudioSource>();
            if (audio)
            {
                audio.Play();
            }
            timeCount = disappearTime;
        }

        if (exploration.explored)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= disappearTime)
            {
                exploration.explored = false;
                timeCount = 0.0f;

                foreach (TextMesh choise in choises)
                {
                    choise.gameObject.SetActive(false);
                }
            }
        }

    }
}
