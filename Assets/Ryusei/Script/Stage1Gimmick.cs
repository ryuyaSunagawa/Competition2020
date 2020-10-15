using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Gimmick : MonoBehaviour
{
    //[SerializeField] GameObject[] BranchObj;    //分岐路のオブジェクト
    //Branch[] BranchScript;                      //分岐路のスクリプト

    [SerializeField] GameObject BranchObj1;    //分岐路のオブジェクト
    [SerializeField] GameObject BranchObj2;    //分岐路のオブジェクト
    [SerializeField] GameObject BranchObj3;    //分岐路のオブジェクト
    Branch BranchScript1;                      //分岐路のスクリプト
    Branch BranchScript2;                      //分岐路のスクリプト
    Branch BranchScript3;                      //分岐路のスクリプト

    public GameObject[] LineObj;    //電線オブジェクト
    [SerializeField] Line[] LineScript;       //電線スクリプト

    [SerializeField] GameObject SwitchObj;      //スイッチのオブジェクト
    Switch SwitchScript;                        //スイッチのスクリプト

    [SerializeField] GameObject DoorObj;     //ドアのオブジェクト
    bool DoorFlg;           //ドアが開いているかひらいていないか

    [SerializeField] GameObject LightObj;    //電球のオブジェクト
    bool LightFlg;          //ゴールの電球がついたかどうか

    // Start is called before the first frame update
    void Start()
    {
        SwitchScript = SwitchObj.GetComponent<Switch>();            //スイッチのスクリプト取得
        BranchScript1 = BranchObj1.GetComponent<Branch>();      //ブランチ[0]のスクリプト取得
        BranchScript2 = BranchObj2.GetComponent<Branch>();      //ブランチ[1]のスクリプト取得
        BranchScript3 = BranchObj3.GetComponent<Branch>();      //ブランチ[1]のスクリプト取得

        for(int i = 0; i <= 11; i++)
        {
            LineScript[i] = LineObj[i].GetComponent<Line>();
        }

        LineScript[0] = LineObj[0].GetComponent<Line>();

        //ギミックの初期数値の設定
        //BranchScript2.BranchRot = 1;    //ブランチ２の回転初期値１
    }

    // Update is called once per frame
    void Update()
    {
        //スイッチが入っているかのフラグ
        if (SwitchScript.SwitchFlg == true)
        {
            for (int i = 0; i <= 3; i++)
            {
                LineObj[i].GetComponent<Renderer>().material.color = Color.yellow;
                LineScript[i].ElectricityFlg = true;
            }
            LineObj[12].GetComponent<Renderer>().material.color = Color.yellow;
            LineObj[13].GetComponent<Renderer>().material.color = Color.yellow;
            LineObj[14].GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            for (int i = 0; i <= 3; i++)
            {
                LineObj[i].GetComponent<Renderer>().material.color = Color.black;
                LineScript[i].ElectricityFlg = false;
            }
            LineObj[12].GetComponent<Renderer>().material.color = Color.black;
            LineObj[13].GetComponent<Renderer>().material.color = Color.black;
            LineObj[14].GetComponent<Renderer>().material.color = Color.black;
        }

        //扉に電気が流れているかのフラグ
        if (SwitchScript.SwitchFlg == true && BranchScript1.BranchRot % 2 != 0)
        {

            DoorObj.GetComponent<Door>().OpenDoor();
            for (int i = 4; i <= 7; i++)
            {
                LineObj[i].GetComponent<Renderer>().material.color = Color.yellow;
                LineScript[i].ElectricityFlg = true;
            }
            LineObj[15].GetComponent<Renderer>().material.color = Color.yellow;
            LineObj[16].GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            DoorObj.GetComponent<Door>().CloseDoor();
            for (int i = 4; i <= 7; i++)
            {
                LineObj[i].GetComponent<Renderer>().material.color = Color.black;
                LineScript[i].ElectricityFlg = false;
            }
            LineObj[15].GetComponent<Renderer>().material.color = Color.black;
            LineObj[16].GetComponent<Renderer>().material.color = Color.black;
        }

        //2個目の分岐が上に電気を流しているか
        if (SwitchScript.SwitchFlg == true && BranchScript1.BranchRot % 2 != 0 && BranchScript2.BranchRot % 2 == 1)
        {
            LineObj[8].GetComponent<Renderer>().material.color = Color.yellow;
            LineScript[8].ElectricityFlg = true;
        }
        else
        {
            LineObj[8].GetComponent<Renderer>().material.color = Color.black;
            LineScript[8].ElectricityFlg = false;
        }

        if (SwitchScript.SwitchFlg == true && BranchScript1.BranchRot % 2 != 0 && (BranchScript2.BranchRot == 1 || BranchScript1.BranchRot % 2 != 0 && BranchScript2.BranchRot == 2))
        {
            LineObj[9].GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            LineObj[9].GetComponent<Renderer>().material.color = Color.black;
        }

            //豆電球に電気が流れているかのフラグ
            if (SwitchScript.SwitchFlg == true && BranchScript1.BranchRot % 2 != 0 && (BranchScript2.BranchRot == 1 || BranchScript2.BranchRot == 2) && BranchScript3.BranchRot % 2 != 0)
        {

            LightObj.GetComponent<Renderer>().material.color = Color.red;
            for (int i = 10; i <= 11; i++)
            {
                LineObj[i].GetComponent<Renderer>().material.color = Color.yellow;
                LineScript[i].ElectricityFlg = true;
            }

        }
        else
        {
            for (int i = 10; i <= 11; i++)
            {
                LineObj[i].GetComponent<Renderer>().material.color = Color.black;
                LineScript[i].ElectricityFlg = false;
            }
        }

    }
}
