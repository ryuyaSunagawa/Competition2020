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

	[SerializeField, Space( 10 )] Sprite greyStarImage;
	[SerializeField] Sprite glowStarImage;

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
		if( displayFlg )
		{
			if( !starImg[ 0 ].enabled )
			{
				foreach( Image star in starImg )
				{
					star.enabled = true;
				}
			}
			clearConditionImg.enabled = true;
			clearConditionText.enabled = true;

			if ( nowScene == "Halloween" )
			{
				Debug.Log( GameManager.Instance.displayStarFlg );
				if ( GameManager.Instance.starInfo2[ 0 ] )
				{
					starImg[ 0 ].sprite = glowStarImage;
				} else if( !GameManager.Instance.starInfo2[ 0 ] )
				{
					starImg[ 0 ].sprite = greyStarImage;
				}

				if ( GameManager.Instance.starInfo3[ 0 ] )
				{
					starImg[ 1 ].sprite = glowStarImage;
				} else if( !GameManager.Instance.starInfo3[ 0 ] )
				{
					starImg[ 1 ].sprite = greyStarImage;
				}

				if ( LoadUserState.Instance.gotStar1[ 0 ] )
				{
					starImg[ 2 ].sprite = glowStarImage;
				} else if( !LoadUserState.Instance.gotStar1[ 0 ] )
				{
					starImg[ 2 ].sprite = greyStarImage;
				}
			}
			else if ( nowScene == "Akimaturi" )
			{
				if ( GameManager.Instance.starInfo2[ 1 ] )
				{
					starImg[ 0 ].sprite = glowStarImage;
				}
				else if ( !GameManager.Instance.starInfo2[ 1 ] )
				{
					starImg[ 0 ].sprite = greyStarImage;
				}

				if ( GameManager.Instance.starInfo3[ 1 ] )
				{
					starImg[ 1 ].sprite = glowStarImage;
				}
				else if ( !GameManager.Instance.starInfo3[ 1 ] )
				{
					starImg[ 1 ].sprite = greyStarImage;
				}

				if ( LoadUserState.Instance.gotStar1[ 1 ] )
				{
					starImg[ 2 ].sprite = glowStarImage;
				}
				else if ( !LoadUserState.Instance.gotStar1[ 1 ] )
				{
					starImg[ 2 ].sprite = greyStarImage;
				}
			}
			else if( nowScene == "Christmas" )
			{
				if ( GameManager.Instance.starInfo2[ 2 ] )
				{
					starImg[ 0 ].sprite = glowStarImage;
				}
				else if ( !GameManager.Instance.starInfo2[ 2 ] )
				{
					starImg[ 0 ].sprite = greyStarImage;
				}

				if ( GameManager.Instance.starInfo3[ 2 ] )
				{
					starImg[ 1 ].sprite = glowStarImage;
				}
				else if ( !GameManager.Instance.starInfo3[ 2 ] )
				{
					starImg[ 1 ].sprite = greyStarImage;
				}

				if ( LoadUserState.Instance.gotStar1[ 2 ] )
				{
					starImg[ 2 ].sprite = glowStarImage;
				}
				else if ( !LoadUserState.Instance.gotStar1[ 2 ] )
				{
					starImg[ 2 ].sprite = greyStarImage;
				}
			}
		}
		else
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
