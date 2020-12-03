using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUIManager : MonoBehaviour
{
	bool pausing = false;

	[SerializeField] CanvasGroup canvasGroup; 

	[SerializeField, Range( 1f, 20f )] float fadeTime = 1f;
	[SerializeField, Range( 0f, 1f )] float fadeLimit = 1f;
	[SerializeField] Button backGameButton;
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
		if ( ( GameManager.Instance.isPause && !pausing ) ||
			 ( !GameManager.Instance.isPause && pausing ) )
		{
			GameManager.Instance.sleepOption = true;
			FadeProcess();
		}

		canvasGroup.blocksRaycasts = GameManager.Instance.isPause;
    }

	void FadeProcess()
	{
		float fadeLimitDelta = Time.unscaledDeltaTime * fadeTime * ( pausing == false ? 1: -1 );
		canvasGroup.alpha += fadeLimitDelta;

		if( ( !pausing && ( canvasGroup.alpha >= fadeLimit ) ) ||
			( pausing && ( canvasGroup.alpha <= 0 ) ) )
		{
			GameManager.Instance.sleepOption = false;
			pausing = !pausing;
			backGameButton.Select();
		}
	}
}
