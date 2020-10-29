using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    bool UpDownFlg;
    bool ElevatorFlg;
    bool ElectricFlg;
    Vector3 FirstPosition;

    [SerializeField] GameObject player;
    [SerializeField] GameObject left;

    // Start is called before the first frame update
    void Start()
    {
        FirstPosition = this.transform.position;
        //Vector3 world = transform.TransformPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= player.transform.position.y)
        {
            UpDownFlg = true;
            ElevatorFlg = true;
            Down();
        }

        if (ElevatorFlg && ElectricFlg)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(UpDownFlg == false) UpDownFlg = true; //昇降
                else if (UpDownFlg == true) UpDownFlg = false; //昇降
            }

            if (UpDownFlg == false) Up(); //昇降
            else if (UpDownFlg == true) Down(); //昇降
        }
    }

    void Up()
    {
        if (transform.position.y <= FirstPosition.y + 3.3f)
        {
            transform.position += new Vector3(0, 0.03f, 0);
        }
    }

    void Down()
    {
        if (FirstPosition.y <= transform.position.y)
        {
            transform.position += new Vector3(0, -0.03f, 0);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ElevatorFlg = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ElevatorFlg = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn")
        {
            ElectricFlg = true;
        }
        else if (other.gameObject.tag == "EnergizedOff")
        {
            ElectricFlg = false;
        }
    }
}
