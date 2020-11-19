using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnManager : MonoBehaviour
{
	[HideInInspector] public bool changing = false;
	bool fading = false;
	bool fadeFlg = false;

	[SerializeField] CanvasGroup canvasGroup;

	[SerializeField, Header( "戻るボタン" )] Button backButton;
	[SerializeField, Header( "キャンセルボタン" )] Button cancelButton;

	[SerializeField, Range( 1f, 20f )] float fadeTime = 1f;
	[SerializeField, Range( 0f, 1f )] float fadeLimit = 1f;
	float fadeVar = 0f;

    // Start is called before the first frame update
    void Start()
    {
		canvasGroup.alpha = 0f;
		canvasGroup.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
		if ( ( changing && !fading ) ||
			 ( !changing && fading ) )
		{
			fadeFlg = true;
		} else
		{
			fadeFlg = false;
		}

		if( fadeFlg )
		{
			FadeProcess();
		}

		canvasGroup.blocksRaycasts = changing;
    }

	void FadeProcess()
	{
		float fadeLimitDelta = Time.unscaledDeltaTime * fadeTime * ( fading == false ? 1: -1 );
		canvasGroup.alpha += fadeLimitDelta;
		Debug.Log( fadeLimitDelta );

		if ( ( changing && canvasGroup.alpha >= fadeLimit ) ||
			 ( !changing && canvasGroup.alpha <= 0 ) )
		{
			fading = !fading;
		}
	}
}
