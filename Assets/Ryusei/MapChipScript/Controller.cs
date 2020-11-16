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
        if (Input.GetButtonDown("B")) Debug.Log("Bボタン");
        if (Input.GetButtonDown("X")) Debug.Log("Xボタン");
        if (Input.GetButtonDown("A")) Debug.Log("Aボタン");
        if (Input.GetButtonDown("Y")) Debug.Log("Yボタン");
        if (Input.GetAxis("Horizontal") < 0) Debug.Log("←" + Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") > 0) Debug.Log("→" + Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Vertical") > 0) Debug.Log("↑" + Input.GetAxis("Vertical"));
        if (Input.GetAxis("Vertical") < 0) Debug.Log("↓" + Input.GetAxis("Vertical"));
        if (Input.GetAxis("R_Horizontal") < 0) Debug.Log(Input.GetAxis("R_Horizontal"));
        if (Input.GetAxis("R_Horizontal") > 0) Debug.Log(Input.GetAxis("R_Horizontal"));
        if (Input.GetAxis("R_Vertical") > 0) Debug.Log(Input.GetAxis("R_Vertical"));
        if (Input.GetAxis("R_Vertical") < 0) Debug.Log(Input.GetAxis("R_Vertical"));
        if (Input.GetAxis("Closs_Vertical") < 0) Debug.Log("CV↑");
        if (Input.GetAxis("Closs_Vertical") > 0) Debug.Log("CV↓");
        if (Input.GetAxis("Closs_Horizontal") < 0) Debug.Log("CH→");
        if (Input.GetAxis("Closs_Horizontal") > 0) Debug.Log("CH←");
        if (Input.GetButtonDown("Start")) Debug.Log("Start");
        if (Input.GetButtonDown("Back")) Debug.Log("Back");
    }
}
