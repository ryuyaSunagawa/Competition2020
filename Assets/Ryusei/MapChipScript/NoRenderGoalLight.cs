using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRenderGoalLight : MonoBehaviour
{

    int changeColor;
    int beforeColor;

    public bool hasLight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                //GetComponentInChildren<Light>().enabled = false;
                hasLight = false;
            }
            else
            {
                //GetComponentInChildren<Light>().enabled = true;
                hasLight = true;
            }

        }
        beforeColor = changeColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn")  //点灯
        {
            //GetComponent<Renderer>().material.color = Color.yellow;
            changeColor = 1;
        }
        else if (other.gameObject.tag == "EnergizedOff")    //消灯
        {
            //GetComponent<Renderer>().material.color = Color.white;
            changeColor = 0;
        }
    }
}
