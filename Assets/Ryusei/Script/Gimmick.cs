using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    //[SerializeField] GameObject[] BranchObj;    //分岐路のオブジェクト
    //Branch[] BranchScript;                      //分岐路のスクリプト

    [SerializeField] GameObject BranchObj1;    //分岐路のオブジェクト
    [SerializeField] GameObject BranchObj2;    //分岐路のオブジェクト
    Branch BranchScript1;                      //分岐路のスクリプト
    Branch BranchScript2;                      //分岐路のスクリプト

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
        
        //ギミックの初期数値の設定
        BranchScript2.BranchRot = 1;    //ブランチ２の回転初期値１
    }

    // Update is called once per frame
    void Update()
    {

        //扉に電気が流れているかのフラグ
        if (SwitchScript.SwitchFlg == true && BranchScript1.BranchRot == 1)
        {
            DoorObj.transform.position += new Vector3(0, 0.1f, 0);
        }

        //豆電球に電気が流れているかのフラグ
        if (SwitchScript.SwitchFlg == true && BranchScript1.BranchRot == 0 && BranchScript2.BranchRot == 0)
        {
            LightObj.GetComponent<Renderer>().material.color = Color.red;
        }

    }
}
