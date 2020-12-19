using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    bool UpDownFlg = true;
    bool ElevatorFlg;
    public bool ElectricFlg;
    Vector3 FirstPosition;

    [SerializeField] GameObject left;

    float time;     //エレベータの扉が閉まるのを待つ時間
    bool timerFlg;  //timeを動かすためのフラグ

    bool isCol;
    float colTimer;
    bool colTimerFlg;  //colTimerを動かすためのフラグ

    [SerializeField] Player playerScript;

    //音-----------------------------------
    AudioSource audioSource;
    public AudioClip powerSE;
    public AudioClip operationSE;
    bool isPowerOneShot;
    bool isOperatopnOneShot;
    float resetTimer; //回転盤を切り替えるたびにポンポンなるのを防ぐ

    // Start is called before the first frame update
    void Start()
    {
        FirstPosition = this.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ElevatorFlg && ElectricFlg)
        {
            if (colTimerFlg) colTimer += Time.deltaTime;  //エレベータ出入口壁の当たり判定を消す
            if (3.5f < colTimer)
            {
                playerScript.isElebator = false;
                colTimer = 0;
                colTimerFlg = false;
            }
            if (isCol)
            {
                isCol = false;

                isOperatopnOneShot = true;  //エレベータ稼働SEを1回だけならす

                if (isOperatopnOneShot)
                {
                    audioSource.PlayOneShot(operationSE);
                    isOperatopnOneShot = false;
                }
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
            if (isPowerOneShot)
            {
                audioSource.PlayOneShot(powerSE);
                isPowerOneShot = false;
            }
            ElectricFlg = true;

            resetTimer = 0;
        }
        else if (other.gameObject.tag == "EnergizedOff")
        {
            resetTimer += Time.deltaTime;

            if (!isPowerOneShot && resetTimer >= 0.8f) isPowerOneShot = true;
            ElectricFlg = false;
        }
    }
}
