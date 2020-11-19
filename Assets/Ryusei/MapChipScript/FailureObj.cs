using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureObj : MonoBehaviour
{
    //GameObject stageManager;    //感電の情報を渡すオブジェクト
    //Failure failureScript;      //感電の情報を渡すスクリプト

    // Start is called before the first frame update
    void Start()
    {
        //stageManager = GameObject.FindGameObjectWithTag("StageManager");
        //failureScript = stageManager.GetComponent<Failure>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn")
        {
            //failureScript.isFailure = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //シーン再読み込み(失敗)
        }
    }
}
