using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureObj : MonoBehaviour
{
	//GameObject stageManager;    //感電の情報を渡すオブジェクト
	//Failure failureScript;      //感電の情報を渡すスクリプト

	bool failFlg = false;

	[SerializeField] ParticleSystem tinyFire;
	[SerializeField] ParticleSystem bigFire;
	float playbackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
		//stageManager = GameObject.FindGameObjectWithTag("StageManager");
		//failureScript = stageManager.GetComponent<Failure>();

		tinyFire.Stop( true );
		bigFire.Stop( true );
    }

    // Update is called once per frame
    void Update()
    {
		if( failFlg )
		{
			if( !tinyFire.isPlaying )
			{
				tinyFire.Play( true );
			}
			playbackTime += Time.deltaTime;

			if( !bigFire.isPlaying && ( playbackTime >= 5f ) )
			{
				bigFire.Play( true );
			}
		}
	}

    private void OnTriggerStay(Collider other)
    {
        if ( !failFlg && other.gameObject.tag == "EnergizedOn" )
        {
			//failureScript.isFailure = true;
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name); //シーン再読み込み(失敗)
			GameManager.Instance.isFail = true;
			failFlg = true;
        }
    }
}
