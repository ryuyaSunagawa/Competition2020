using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseUIManager : MonoBehaviour
{
	bool pausing = false;

	[SerializeField] CanvasGroup canvasGroup; 

	[SerializeField, Range( 1f, 20f )] float fadeTime = 1f;
	[SerializeField, Range( 0f, 1f )] float fadeLimit = 1f;
	[SerializeField] Button backGameButton;
	float fadeVar = 0f;

	[SerializeField] Text conditionText1;
	[SerializeField] Text conditionText2;
	[SerializeField] Text conditionText3;

    // Start is called before the first frame update
    void Start()
    {
		canvasGroup.alpha = 0f;
		canvasGroup.blocksRaycasts = false;
		conditionText1.text = GameManager.Instance.sceneInformation.star1Text;
		conditionText2.text = GameManager.Instance.sceneInformation.star2Text;
		conditionText3.text = GameManager.Instance.sceneInformation.star3Text;
    }

    // Update is called once per frame
    void Update()
    {
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
