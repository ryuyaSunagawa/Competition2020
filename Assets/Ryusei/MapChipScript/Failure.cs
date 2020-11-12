using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Failure : MonoBehaviour
{
    const int textsNum = 4;
    [SerializeField] GameObject[] failureTexts;
    [SerializeField] GameObject cursorImage;

    public bool isFailure;

    int cursor = 0;

    RectTransform cursorPosition;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < textsNum; i++)
        {
            failureTexts[i].SetActive(false);
        }
        cursorImage.SetActive(false);

        cursorPosition = cursorImage.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFailure)
        {
            //失敗時の処理をここに書く
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //シーン再読み込み(仮置き)
            for (int i = 0; i < textsNum; i++)
            {
                failureTexts[i].SetActive(true);
            }

            cursorImage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.W)){
                if (cursor == 0)
                {
                    cursor = -1;
                }
                else
                {
                    cursor += 1;
                }

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (cursor == -1)
                {
                    cursor = 0;
                }
                else
                {
                    cursor -= 1;
                }
            }

            cursorPosition.localPosition = new Vector3(0, cursor*70, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(cursor == 0)
            {

            }else if(cursor == -1) //リトライの処理
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //シーン再読み込み
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "EnergizedOn")  //点灯
    //    {
    //        hasElectrical = true;
    //    }
    //}
}
