using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneStarUI : MonoBehaviour
{
	[SerializeField] CanvasGroup myCanvasGroup;
	[SerializeField, Header( "星画像" )] Image[] starImg = new Image[ 3 ];
	[SerializeField] Image clearConditionImg;
	[SerializeField] Text clearConditionText;
	[SerializeField, Space( 15 )] HalloweenStage halloweenStage;
	[SerializeField] AkimaturiStage akimaturiStage;
	[SerializeField] ChristmasStage christmasStage;

    // Start is called before the first frame update
    void Start()
    {
		clearConditionText.text = LoadUserState.Instance.stageInfo[ SceneManager.GetActiveScene().buildIndex - 3 ].star1Text;
    }

	// Update is called once per frame
	void Update()
	{
		if ( GameManager.Instance.displayStarFlg ) {
			JudgeDisplayState( GameManager.Instance.nowScene, true );
		} else if( !GameManager.Instance.displayStarFlg )
		{
			JudgeDisplayState( GameManager.Instance.nowScene, false );
		}
	}

	/// <summary>
	///　星の表示判定処理(displayフラグがtrueなら星を表示しない)
	/// </summary>
	/// <param name="nowScene"></param>
	/// <param name="displayFlg"></param>
	void JudgeDisplayState( string nowScene, bool displayFlg )
	{
		if( displayFlg ) {
			for ( int i = 1; i <= 3; i++ )
			{
				if( nowScene == "HalloweenStage" ) { 
					if ( halloweenStage.star >= i )
					{
						starImg[ i - 1 ].enabled = true;
					}
					else
					{
						starImg[ i - 1 ].enabled = false;
					}
				}
				else if ( nowScene == "AkimaturiStage" )
				{
					if ( akimaturiStage.star >= i )
					{
						starImg[ i - 1 ].enabled = true;
					}
					else
					{
						starImg[ i - 1 ].enabled = false;
					}
				} else if( nowScene == "ChristmasStage" ) { 
					if ( christmasStage.star >= i )
					{
						starImg[ i - 1 ].enabled = true;
					}
					else
					{
						starImg[ i - 1 ].enabled = false;
					}
				}
			}

			clearConditionImg.enabled = true;
			clearConditionText.enabled = true;
		} else
		{
			for ( int i = 1; i <= 3; i++ )
			{
				starImg[ i - 1 ].enabled = false;
			}

			//クリア条件の非表示
			clearConditionImg.enabled = false;
			clearConditionText.enabled = false;
		}
	}
}
