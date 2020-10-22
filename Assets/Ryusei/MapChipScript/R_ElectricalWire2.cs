using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_ElectricalWire2 : MonoBehaviour
{

    bool EnergizedFlg;
    BoxCollider collider;
    GameObject PowerButton;

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
            GetComponent<Renderer>().material.color = Color.black;
            Invoke("DelayMethod", 0.02f);
        }
        else if (other.gameObject.tag == "EnergizedOn" && PowerButton.tag == "EnergizedOn")
        {
            this.tag = "EnergizedOn";
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (other.gameObject.tag == "EnergizedOff" && PowerButton.tag == "EnergizedOff")
        {
            this.tag = "EnergizedOff";
            GetComponent<Renderer>().material.color = Color.black;
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

