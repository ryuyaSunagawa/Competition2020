using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StageSelector : MonoBehaviour
{
	[Header( "ステージ番号" )]				public int stageNumber = 0;
	[Header( "ステージ名" )]				public string stageName = "";
	[Header( "シーン名" )]					public string stageSceneName = "";
	[Header( "ステージ概要" ), TextArea]	public string stageSummary = "";
	[Header( "獲得条件1" ), TextArea]		public string star1Text = "";
	[Header( "獲得条件2" ), TextArea]		public string star2Text = "";
	[Header( "獲得条件3" ), TextArea]		public string star3Text = "";

    // Start is called before the first frame update
    void Start()
    {
		//ステージ情報取得
		stageName = LoadUserState.Instance.stageInfo[ stageNumber - 1 ].stageName;
		stageSceneName = LoadUserState.Instance.stageInfo[ stageNumber - 1 ].stageSceneName;
		stageSummary = LoadUserState.Instance.stageInfo[ stageNumber - 1 ].stageSummary;
		star1Text = LoadUserState.Instance.stageInfo[ stageNumber - 1 ].star1Text;
		star2Text = LoadUserState.Instance.stageInfo[ stageNumber - 1 ].star2Text;
		star3Text = LoadUserState.Instance.stageInfo[ stageNumber - 1 ].star3Text;

		//ステージ名
		GetComponentInChildren<Text>().text = stageName;
    }

    // Update is called once per frame
    void Update()
    {
        if( LoadUserState.Instance.GetProgress() + 1 >= stageNumber )
		{
			this.GetComponent<Button>().interactable = true;
			//Debug.Log( LoadUserState.Instance.GetProgress() );
		}
    }
}
