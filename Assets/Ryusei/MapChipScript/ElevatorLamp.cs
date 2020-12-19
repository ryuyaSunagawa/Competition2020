using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLamp : MonoBehaviour
{
    public int changeColor;
    int beforeColor;

    MeshRenderer meshRenderer;//
    bool MatChange = false;//
    [SerializeField] Material[] materials1;//
    [SerializeField] Material[] materials2;//

    [SerializeField] Elevator elevatorScript;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(elevatorScript.ElectricFlg) changeColor = 1;
        else if(!elevatorScript.ElectricFlg) changeColor = 0;

        if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                //GetComponent<Renderer>().material.color = Color.white;
                MatChange = false;
            }
            else
            {
                //GetComponent<Renderer>().material.color = Color.yellow;
                MatChange = true;
            }

        }
        beforeColor = changeColor;
        meshRenderer.materials = MatChange ? materials2 : materials1;//
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "EnergizedOn")  //点灯
    //    {
    //        //GetComponent<Renderer>().material.color = Color.yellow;
    //        changeColor = 1;
    //    }
    //    else if (other.gameObject.tag == "EnergizedOff")    //消灯
    //    {
    //        //GetComponent<Renderer>().material.color = Color.white;
    //        changeColor = 0;
    //    }
    //}
}
