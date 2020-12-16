using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailBom : MonoBehaviour
{
    //GameObject stageManager;    //感電の情報を渡すオブジェクト
    //Failure failureScript;      //感電の情報を渡すスクリプト

    bool failFlg = false;

    float playbackTime = 0f;

    AudioSource audioSource;
    bool isOneShot;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (failFlg)
        {
            if (!isOneShot)
            {
                audioSource.Play();
                isOneShot = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!failFlg && other.gameObject.tag == "EnergizedOn")
        {
            //failureScript.isFailure = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //シーン再読み込み(失敗)
            GameManager.Instance.isFail = true;
            failFlg = true;
        }
    }
}
