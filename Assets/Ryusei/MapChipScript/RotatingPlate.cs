using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlate : MonoBehaviour
{
    int BranchRot = 0;
    bool BranchFlg;
    GameObject[] RotatingWire;

    // Start is called before the first frame update
    void Start()
    {
        RotatingWire = new GameObject[2];
        RotatingWire[0] =transform.GetChild(0).gameObject;
        RotatingWire[1] = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (BranchFlg == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (BranchRot >= 3) BranchRot = 0;
                else BranchRot += 1;

                this.tag = "EnergizedOff";
                RotatingWire[0].GetComponent<Renderer>().material.color = Color.black;
                RotatingWire[1].GetComponent<Renderer>().material.color = Color.black;

                transform.rotation = Quaternion.Euler(0, BranchRot * 90, 0);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BranchFlg = true;
        }

        if (other.gameObject.tag == "EnergizedOn")
        {
            this.tag = "EnergizedOn";
            RotatingWire[0].GetComponent<Renderer>().material.color = Color.yellow;
            RotatingWire[1].GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (other.gameObject.tag == "EnergizedOff")
        {
            this.tag = "EnergizedOff";
            RotatingWire[0].GetComponent<Renderer>().material.color = Color.black;
            RotatingWire[1].GetComponent<Renderer>().material.color = Color.black;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BranchFlg = false;
        }
    }
}
