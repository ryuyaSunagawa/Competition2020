using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnManager : MonoBehaviour
{
	public Button firstButton = null;
	public Button finishButton = null;

	[HideInInspector] public bool isSelect = false;
	//[HideInInspector] public bool changing = false;
	bool selectBefore = false;

	CanvasGroup myCanvasGroup;

	[SerializeField, Range( 1f, 20f )] float fadeTime = 1f;
	[SerializeField, Range( 0f, 1f )] float fadeLimit = 1f;

    // Start is called before the first frame update
    void Start()
    {
		myCanvasGroup = GetComponent<CanvasGroup>();
		myCanvasGroup.alpha = 0f;
		myCanvasGroup.interactable = false;
		myCanvasGroup.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
		//パネルチェンジフラグとフェードフラグが等しくなければ
		//FadeProcessを実行する
		if( isSelect != selectBefore )
		{
			FadeProcess();
		}
    }

	void FadeProcess()
	{
		float fadeLimitDelta = Time.unscaledDeltaTime * fadeTime * ( selectBefore == false ? 1: -1 );
		myCanvasGroup.alpha += fadeLimitDelta;

		if ( ( isSelect && myCanvasGroup.alpha >= fadeLimit ) ||
			 ( !isSelect && myCanvasGroup.alpha <= 0 ) )
		{
			if( myCanvasGroup.alpha >= fadeLimit )
			{
				firstButton.Select();
			} else
			{
				finishButton.Select();
			}
			selectBefore = isSelect;
			myCanvasGroup.interactable = isSelect;
			myCanvasGroup.blocksRaycasts = isSelect;
		}
	}
}
