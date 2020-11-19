using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearController : MonoBehaviour
{
	//クリアフラグ
	[HideInInspector] public bool clearFlg { set; get; }
	//スター獲得個数
	[HideInInspector] public int evaluationStar { set; get; }

	bool fadeFlg;
	float fadeValue = 0;
	[SerializeField] CanvasGroup canvasGroup;
	[SerializeField, Range( 1f, 20f ), Header( "フェードスピード" )] float fadeTime = 1f;
	[SerializeField, Range( 0f, 1f )] float fadeLimit = 1f;
	[SerializeField] bool isClearCanvas;
	[SerializeField] ClearReturnManager clearButton;
	[SerializeField] Button nextButton;

	// Start is called before the first frame update
	void Start()
    {
		//clearFlg = false;
		//evaluationStar = 0;
		//fadeFlg = false;
		//canvasGroup.alpha = 0f;
		//canvasGroup.blocksRaycasts = fadeFlg;
    }

    // Update is called once per frame
    void Update()
    {
		if( isClearCanvas && ( clearFlg != fadeFlg ) )
		{
			Invoke( "RaiseFrag", 1.0f );
			fadeFlg = clearFlg;
			nextButton.Select();
		}
  //      if( clearFlg != fadeFlg )
		//{
		//	canvasGroup.alpha += Time.unscaledDeltaTime * fadeTime;
		//	if( canvasGroup.alpha == 1 )
		//	{
		//		fadeFlg = true;
		//		if( isClearCanvas )
		//		{
		//			Invoke( "RaiseFrag", 1.0f );
		//		}
		//	}
		//}
    }

	void RaiseFrag()
	{
		clearButton.changing = true;
	}
}
