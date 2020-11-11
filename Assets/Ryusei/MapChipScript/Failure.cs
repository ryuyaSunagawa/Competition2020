using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Failure : MonoBehaviour
{

    bool hasElectrical;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasElectrical)
        {
            //失敗時の処理をここに書く
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //シーン再読み込み(仮置き)
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn")  //点灯
        {
            hasElectrical = true;
        }
    }
}
