using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWire : MonoBehaviour
{

    GameObject PowerButton;

    // Start is called before the first frame update
    void Start()
    {
        PowerButton = GameObject.FindGameObjectWithTag("PowerButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn" && PowerButton.tag == "EnergizedOn")
        {
            this.tag = "EnergizedOn";
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        //else if (other.gameObject.tag == "EnergizedOff")
        //{
        //    this.tag = "EnergizedOff";
        //    GetComponent<Renderer>().material.color = Color.black;
        //}
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "EnergizedOn")
        {
            this.tag = "EnergizedOn";
            GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
