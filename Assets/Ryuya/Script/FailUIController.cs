using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailUIController : MonoBehaviour
{
	[HideInInspector] public bool isFailed { set; get; }

	bool firstFailedFlg = false;
	bool doneFadeFlg = false;
	float fadeValue = 0f;
	[SerializeField] CanvasGroup canvasGroup;
	[SerializeField, Range( 1f, 20f ), Header( "フェードスピード" )] float fadeTime = 1f;
	[SerializeField] Button firstButton;
	//[SerializeField, Range( 0f, 1f )] float fadeLimit = 1f;

	// Start is called before the first frame update
	void Start()
    {
		isFailed = false;
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
		if( GameManager.Instance.isFail != firstFailedFlg )
		{
			canvasGroup.interactable = true;
			//Cursor.lockState = CursorLockMode.None;
			firstFailedFlg = true;
		}
        if( GameManager.Instance.isFail != doneFadeFlg )
		{
			canvasGroup.alpha += Time.unscaledDeltaTime * fadeTime;
			if( canvasGroup.alpha == 1 )
			{
				firstButton.Select();
				canvasGroup.blocksRaycasts = true;
				doneFadeFlg = true;
			}
		}
    }
}
