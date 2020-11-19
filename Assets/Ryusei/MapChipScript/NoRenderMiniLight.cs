using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRenderMiniLight : MonoBehaviour
{
    int changeColor;
    int beforeColor;

    public bool hasLight;

    int childCount; //子オブジェクトの数
    [SerializeField]GameObject[] childObject;

    // Start is called before the first frame update
    void Start()
    {
        childCount = transform.childCount; //子オブジェクトの数取得
        for (int i = 0; i < childCount; i++)
        {
            childObject[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    childObject[i].GetComponentInChildren<Light>().enabled = false;
                }
                hasLight = false;
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    childObject[i].GetComponentInChildren<Light>().enabled = true;
                }
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
