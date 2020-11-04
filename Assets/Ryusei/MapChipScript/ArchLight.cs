﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchLight : MonoBehaviour
{
    int changeColor;
    int beforeColor;

    MeshRenderer meshRenderer;//
    bool MatChange = false;//
    [SerializeField] Material[] materials1;//
    [SerializeField] Material[] materials2;//

    public bool hasLight;

    GameObject PowerButton;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        PowerButton = GameObject.FindGameObjectWithTag("PowerButton");
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                MatChange = false;
                hasLight = false;
            }
            else
            {
                MatChange = true;
                hasLight = true;
            }

        }
        beforeColor = changeColor;
        meshRenderer.materials = MatChange ? materials2 : materials1;//
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BlackOut")
        {
            this.tag = "BlackOut";
        }

        if (gameObject.tag == "BlackOut")
        {
            //GetComponent<Renderer>().material.color = Color.black;
            changeColor = 0;
            Invoke("DelayMethod", 0.02f);
        }
        else if (other.gameObject.tag == "EnergizedOn" && PowerButton.tag == "EnergizedOn")  //点灯
        {
            changeColor = 1;
            this.tag = "EnergizedOn";
        }
        else if (other.gameObject.tag == "EnergizedOff" && PowerButton.tag == "EnergizedOff")    //消灯
        {
            changeColor = 0;
            this.tag = "EnergizedOff";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "ElectricalDoor")
        {
            this.tag = "BlackOut";
        }
    }

    void DelayMethod()
    {
        this.tag = "EnergizedOff";
    }
}
