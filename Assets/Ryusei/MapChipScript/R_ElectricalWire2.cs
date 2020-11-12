using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R_ElectricalWire2 : MonoBehaviour
{
    GameObject PowerButton;
    int changeColor;    //0,黒 1,黄色
    int beforeColor;

    // Start is called before the first frame update
    void Start()
    {
        PowerButton = GameObject.FindGameObjectWithTag("PowerButton");
    }

    // Update is called once per frame
    void Update()
    {
        if( beforeColor != changeColor)
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

        if (other.gameObject.tag != "Player" && other.gameObject.tag != "ElectricalDoor")
        {
            this.tag = "BlackOut";
        }else if(other.gameObject.tag == "Player" && gameObject.tag == "EnergizedOn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //シーン再読み込み(感電)
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "BlackOut")
        {
            this.tag = "BlackOut";
        }

        if (gameObject.tag == "BlackOut")
        {
            changeColor = 0;
            Invoke("DelayMethod", 0.02f);
        }
        else if (other.gameObject.tag == "EnergizedOn" && PowerButton.tag == "EnergizedOn")
        {
            this.tag = "EnergizedOn";
            changeColor = 1;
        }
        else if (other.gameObject.tag == "EnergizedOff" && PowerButton.tag == "EnergizedOff")
        {
            this.tag = "EnergizedOff";
            changeColor = 0;
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

