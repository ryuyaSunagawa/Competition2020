﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasDeco : MonoBehaviour
{
    int changeColor;
    int beforeColor;

    MeshRenderer meshRenderer;//
    bool MatChange = false;//
    [SerializeField] Material[] materials1;//
    [SerializeField] Material[] materials2;//

    public bool hasLight;

    GameObject goalLight;
    NoRenderGoalLight goalLightScript;

    GameObject stageManager;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        goalLight = GameObject.FindGameObjectWithTag("GoalLight");
        goalLightScript = goalLight.GetComponent<NoRenderGoalLight>();

        stageManager = GameObject.FindGameObjectWithTag("StageManager");
    }

    // Update is called once per frame
    void Update()
    {
        //if (goalLightScript.hasLight)  //点灯
        if(stageManager.gameObject.tag == "AllStar")
        {
            //GetComponent<Renderer>().material.color = Color.yellow;
            changeColor = 1;
        }
        //else if (!goalLightScript.hasLight)    //消灯
        //{
        //    //GetComponent<Renderer>().material.color = Color.white;
        //    changeColor = 0;
        //}

        if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                //GetComponent<Renderer>().material.color = Color.white;
                MatChange = false;
                hasLight = false;
            }
            else
            {
                //GetComponent<Renderer>().material.color = Color.yellow;
                MatChange = true;
                hasLight = true;
            }

        }
        beforeColor = changeColor;
        meshRenderer.materials = MatChange ? materials2 : materials1;//
    }
}
