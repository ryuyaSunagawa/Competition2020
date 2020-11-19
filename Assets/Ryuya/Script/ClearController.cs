using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	// Start is called before the first frame update
	void Start()
    {
		clearFlg = false;
		evaluationStar = 0;
		fadeFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( clearFlg != fadeFlg )
		{
			canvasGroup.alpha += Time.deltaTime * fadeTime;
			if( canvasGroup.alpha == 1 )
			{
				fadeFlg = true;
			}
		}
    }
}
