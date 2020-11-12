using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    float x , y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LB")) Debug.Log("LBボタンorQキー");
        if (Input.GetButtonDown("RB")) Debug.Log("RBボタンorEキー");
        if (Input.GetButtonDown("B")) Debug.Log("BボタンorSpaceキー");
        if (Input.GetButtonDown("X")) Debug.Log("XボタンorSpaceキー");
        if (Input.GetButtonDown("A")) Debug.Log("AボタンorSpaceキー"); 
        if (Input.GetAxis("Horizontal") < 0) Debug.Log("左スティック←");
        if (Input.GetAxis("Horizontal") > 0) Debug.Log("左スティック→");
        if (Input.GetAxis("Vertical") > 0) Debug.Log("左スティック↑");
        if (Input.GetAxis("Vertical") < 0) Debug.Log("左スティック↓");
        if (Input.GetAxis("R_Horizontal") < 0) Debug.Log(Input.GetAxis("R_Horizontal"));
        if (Input.GetAxis("R_Horizontal") > 0) Debug.Log(Input.GetAxis("R_Horizontal"));
        if (Input.GetAxis("R_Vertical") > 0) Debug.Log(Input.GetAxis("R_Vertical"));
        if (Input.GetAxis("R_Vertical") < 0) Debug.Log(Input.GetAxis("R_Vertical"));
    }
}
