using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClearButtonManager : MonoBehaviour
{
	const float fadeLimit = 1f;
	[HideInInspector] public bool changing = false;
	bool fading = false;
	bool fadeFlg = false;

	[SerializeField] CanvasGroup canvasGroup;
	CanvasGroup myCanvasGroup;

	[SerializeField, Range( 1f, 20f )] float fadeTime = 1f;
	[SerializeField] Button firstButton;

	// Start is called before the first frame update
	void Start()
	{
		myCanvasGroup = GetComponent<CanvasGroup>();
		myCanvasGroup.alpha = 0f;
		myCanvasGroup.blocksRaycasts = false;
	}

	// Update is called once per frame
	void Update()
	{
		if ( ( changing && !fading ) ||
			 ( !changing && fading ) )
		{
			fadeFlg = true;
		}
		else
		{
			fadeFlg = false;
		}

		if ( fadeFlg )
		{
			FadeProcess();
		}
		//Debug.Log( EventSystem.current.currentSelectedGameObject.name );
	}

	void FadeProcess()
	{
		float fadeLimitDelta = Time.unscaledDeltaTime * fadeTime * ( fading == false ? 1 : -1 );
		myCanvasGroup.alpha += fadeLimitDelta;

		if ( ( changing && myCanvasGroup.alpha >= fadeLimit ) ||
			 ( !changing && myCanvasGroup.alpha <= 0 ) )
		{
			fading = !fading;
			//キャンバスグループのレイキャスト有効化
			myCanvasGroup.blocksRaycasts = true;
			//キャンバスグループの選択有効化
			myCanvasGroup.interactable = true;

			//初期選択ボタン
			firstButton.Select();
		}
	}
}
