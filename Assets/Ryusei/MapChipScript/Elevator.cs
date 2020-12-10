using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    bool UpDownFlg = true;
    bool ElevatorFlg;
    bool ElectricFlg;
    Vector3 FirstPosition;

    [SerializeField] GameObject left;

    float time;     //エレベータの扉が閉まるのを待つ時間
    bool timerFlg;  //timeを動かすためのフラグ

    bool isCol;
    float colTimer;
    bool colTimerFlg;  //colTimerを動かすためのフラグ

    [SerializeField] Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        FirstPosition = this.transform.position;
        //Vector3 world = transform.TransformPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (transform.position.y >= player.transform.position.y)
        //{
        //    UpDownFlg = true;
        //    ElevatorFlg = true;
        //    Down();
        //}
        //Debug.Log("ElevatorFlg" + ElevatorFlg);
        //Debug.Log("ElectricFlg" + ElectricFlg);
        //Debug.Log(timerFlg);

        if (ElevatorFlg && ElectricFlg)
        {
            if (colTimerFlg) colTimer += Time.deltaTime;  //エレベータ出入口壁の当たり判定を消す
            if (3.5f < colTimer)
            {
                playerScript.isElebator = false;
                //col[3].enabled = false;
                //col[4].enabled = false;
                colTimer = 0;
                colTimerFlg = false;
            }
            if (isCol)
            {
                //col[3].enabled = true;
                //col[4].enabled = true;
                isCol = false;
            }

            if (timerFlg) time += Time.deltaTime;  //扉が閉まるのを待ってから動く

            if (1.0f < time)
            {
                if (UpDownFlg == false) UpDownFlg = true; //昇降
                else if (UpDownFlg == true) UpDownFlg = false; //昇降

                time = 0;
                timerFlg = false;
            }

            if (UpDownFlg == false) Up(); //昇降
            else if (UpDownFlg == true) Down(); //昇降
        }
    }

    void Up()
    {
        if (transform.position.y <= FirstPosition.y + 5.0f)
        {
            transform.position += new Vector3(0, 0.05f, 0);
        }
    }

    void Down()
    {
        if (FirstPosition.y <= transform.position.y)
        {
            transform.position += new Vector3(0, -0.05f, 0);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.isElebator = true;
            ElevatorFlg = true;
            timerFlg = true;
            colTimerFlg = true;
            isCol = true;
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
