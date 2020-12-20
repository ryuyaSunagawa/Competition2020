using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseUIManager : MonoBehaviour
{
	public bool pausing = false;

	[SerializeField] CanvasGroup canvasGroup; 

	[SerializeField, Range( 1f, 20f )] float fadeTime = 1f;
	[SerializeField, Range( 0f, 1f )] float fadeLimit = 1f;
	[SerializeField] Button backGameButton;
	float fadeVar = 0f;

	[SerializeField] Text conditionText1;
	[SerializeField] Text conditionText2;
	[SerializeField] Text conditionText3;
	[SerializeField] Image[] conditionStar = new Image[ 3 ];

	[SerializeField] Sprite greyStarSprite;
	[SerializeField] Sprite glowStarSprite;

    // Start is called before the first frame update
    void Start()
    {
		canvasGroup.alpha = 0f;
		canvasGroup.blocksRaycasts = false;
		conditionText1.text = GameManager.Instance.sceneInformation.star1Text;
		conditionText2.text = GameManager.Instance.sceneInformation.star2Text;
		conditionText3.text = GameManager.Instance.sceneInformation.star3Text;
		for( int i = 0; i < 3; i++ )
		{
			if( i == 0 && GameManager.Instance.starInfo1[ 0 ] )
			{
				conditionStar[ i ].sprite = glowStarSprite;
			}
			else if( i == 0 && !GameManager.Instance.starInfo1[ 0 ] )
			{
				conditionStar[ i ].sprite = greyStarSprite;
			}

			if( i == 1 && GameManager.Instance.starInfo2[ 0 ] )
			{
				conditionStar[ i ].sprite = glowStarSprite;
			}
			else if( i == 1 && !GameManager.Instance.starInfo2[ 0 ] )
			{
				conditionStar[ i ].sprite = greyStarSprite;
			}

			if ( i == 2 && GameManager.Instance.starInfo3[ 0 ] )
			{
				conditionStar[ i ].sprite = glowStarSprite;
			}
			else if( i == 2 && !GameManager.Instance.starInfo3[ 0 ] )
			{
				conditionStar[ i ].sprite = greyStarSprite;
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
		for ( int i = 0; i < 3; i++ )
		{
			if ( i == 0 && GameManager.Instance.starInfo1[ 0 ] )
			{
				conditionStar[ i ].sprite = glowStarSprite;
			}
			else if ( i == 0 && !GameManager.Instance.starInfo1[ 0 ] )
			{
				conditionStar[ i ].sprite = greyStarSprite;
			}

			if ( i == 1 && GameManager.Instance.starInfo2[ 0 ] )
			{
				conditionStar[ i ].sprite = glowStarSprite;
			}
			else if ( i == 1 && !GameManager.Instance.starInfo2[ 0 ] )
			{
				conditionStar[ i ].sprite = greyStarSprite;
			}

			if ( i == 2 && GameManager.Instance.starInfo3[ 0 ] )
			{
				conditionStar[ i ].sprite = glowStarSprite;
			}
			else if ( i == 2 && !GameManager.Instance.starInfo3[ 0 ] )
			{
				conditionStar[ i ].sprite = greyStarSprite;
			}
		}

		if ( GameManager.Instance.isPause && !pausing )
		{
			FadeProcess();
		}
		else if( !GameManager.Instance.isPause && pausing )
		{
			//GameManager.Instance.sleepOption = true;
			FadeProcess();
		}

		//canvasGroup.blocksRaycasts = GameManager.Instance.isPause;
    }

	void FadeProcess()
	{
		float fadeLimitDelta = Time.unscaledDeltaTime * fadeTime * ( pausing == false ? 1: -1 );
		canvasGroup.alpha += fadeLimitDelta;

		if( !pausing && ( canvasGroup.alpha >= fadeLimit ) ) 
		{
			GameManager.Instance.sleepOption = false;
			GameManager.Instance.isPause = true;
			pausing = !pausing;
			//BackGameButton初期設定
			backGameButton.interactable = true;
			backGameButton.Select();
			canvasGroup.blocksRaycasts = true;
			canvasGroup.interactable = true;
		}
		else if( pausing && ( canvasGroup.alpha <= 0 ) )
		{
			GameManager.Instance.sleepOption = true;
			EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().interactable = false;
			pausing = !pausing;
			canvasGroup.blocksRaycasts = false;
			canvasGroup.interactable = false;
		}
	}
}
