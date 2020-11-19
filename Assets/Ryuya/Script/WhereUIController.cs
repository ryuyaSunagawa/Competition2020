using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereUIController : MonoBehaviour
{
	[HideInInspector] public bool isFailed { set; get; }

	bool doneFadeFlg = false;
	float fadeValue = 0f;
	[SerializeField] CanvasGroup canvasGroup;
	[SerializeField, Range( 1f, 20f ), Header( "フェードスピード" )] float fadeTime = 1f;
	//[SerializeField, Range( 0f, 1f )] float fadeLimit = 1f;

	// Start is called before the first frame update
	void Start()
	{
		isFailed = false;
		canvasGroup.alpha = 0;
		canvasGroup.blocksRaycasts = false;
	}

	// Update is called once per frame
	void Update()
	{
		if ( GameManager.Instance.isFail != doneFadeFlg )
		{
			canvasGroup.alpha += Time.deltaTime * fadeTime;
			if ( canvasGroup.alpha == 1 )
			{
				canvasGroup.blocksRaycasts = true;
				doneFadeFlg = true;
			}
		}
	}
}
