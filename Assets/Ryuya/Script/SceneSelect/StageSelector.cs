using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
