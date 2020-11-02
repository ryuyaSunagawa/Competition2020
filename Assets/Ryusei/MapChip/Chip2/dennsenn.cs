using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dennsenn : MonoBehaviour
{
    [SerializeField] bool isDebug;
    BoxCollider[] collider;

    int changeColor;    //0,黒 1,黄色
    int beforeColor;
    bool enterFlg;  //Enterで処理を実行させないためのフラグ

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponents<BoxCollider>();
        enterFlg = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                GetComponent<Renderer>().material.color = Color.black;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.yellow;
            }

        }
        beforeColor = changeColor;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (enterFlg)
        {
            if (collider[0])
            {
                collider[1].enabled = false;
                collider[2].enabled = false;
                if (isDebug) Debug.Log("0がExit");
            }
            else if (collider[1])
            {
                collider[0].enabled = false;
                collider[2].enabled = false;
                if (isDebug) Debug.Log("1がExit");
            }
            else if (collider[2])
            {
                collider[0].enabled = false;
                collider[1].enabled = false;
                if (isDebug) Debug.Log("2がExit");
            }

            //Invoke("DelayMethod", 0.02f);

            if (other.tag != "BlackOut")
            {
                if (tag == "EnergizedOn" && other.tag == "EnergizedOff") {
                    tag = "EnergizedOff";
                    changeColor = 0;
                }
                else if (tag == "EnergizedOff" && other.tag == "EnergizedOn") {
                    tag = "EnergizedOn";
                    changeColor = 1;
                }
            }
            else if(other.tag == "BlackOut")
            {
                tag = "BlackOut";
                changeColor = 0;
                Invoke("DelayBlackOut", 0.02f);
            }
        }

        if (isDebug) Debug.Log("Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        enterFlg = false;

        collider[0].enabled = true;
        collider[1].enabled = true;
        collider[2].enabled = true;

        Invoke("DelayEnterFlg", 0.02f);

        if (isDebug) Debug.Log("Exit");
    }

    void DelayEnterFlg()
    {
        //collider[0].enabled = true;
        //collider[1].enabled = true;
        //collider[2].enabled = true;
        enterFlg = true;
    }
    void DelayEnergizedOff()
    {
        tag = "EnergizedOff";
    }
}
