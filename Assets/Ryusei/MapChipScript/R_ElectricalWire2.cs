using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R_ElectricalWire2 : MonoBehaviour
{

    bool EnergizedFlg;
    BoxCollider collider;
    GameObject PowerButton;
    int changeColor;    //0,黒 1,黄色
    int beforeColor;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
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

        //i++;
        //Debug.Log(i);
        //if (other.gameObject.tag == "EnergizedOn" && PowerButton.tag == "EnergizedOn")
        //{
        //    this.tag = "EnergizedOn";
        //    GetComponent<Renderer>().material.color = Color.yellow;
        //}
        //else if (other.gameObject.tag == "EnergizedOff" && PowerButton.tag == "EnergizedOff")
        //{
        //    this.tag = "EnergizedOff";
        //    GetComponent<Renderer>().material.color = Color.black;
        //}

        //collider.size = new Vector3(0, 0, 0); //
        //Invoke("DelayMethod", 0.02f);
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
            //GetComponent<Renderer>().material.color = Color.black;
            changeColor = 0;
            Invoke("DelayMethod", 0.02f);
        }
        else if (other.gameObject.tag == "EnergizedOn" && PowerButton.tag == "EnergizedOn")
        {
            this.tag = "EnergizedOn";
            changeColor = 1;
            //GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (other.gameObject.tag == "EnergizedOff" && PowerButton.tag == "EnergizedOff")
        {
            this.tag = "EnergizedOff";
            changeColor = 0;
            //GetComponent<Renderer>().material.color = Color.black;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //this.tag = "EnergizedOff";
        //GetComponent<Renderer>().material.color = Color.black;
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "ElectricalDoor")
        {
            this.tag = "BlackOut";
        }
    }

    void DelayMethod()
    {
        //collider.size = new Vector3(1, 1, 1);
        this.tag = "EnergizedOff";
    }
}

