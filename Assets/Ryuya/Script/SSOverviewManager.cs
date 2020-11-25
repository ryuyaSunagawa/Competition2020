using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// SceneTo: SceneSelectScene
/// シーン概要ウィンドウのマネージャー
/// </summary>
public class SSOverviewManager : MonoBehaviour
{
	[HideInInspector] public bool isSelect = false;
	bool difFirstFlg = false;
	bool difFlg = false;

	[SerializeField, Range( 1f, 10f )] float fadeSpeed = 0f;

	CanvasGroup myCanvasGroup;

	[SerializeField] Button firstButton = null;
	public			 Button nowButton = null;

	[SerializeField] Text stageNameText = null;

	[HideInInspector] public StageSelector ss = null;
    // Start is called before the first frame update
    void Start()
    {
		//canvasgroup初期化
		myCanvasGroup = GetComponent<CanvasGroup>();
		myCanvasGroup.alpha = 0f;
		myCanvasGroup.interactable = false;
		myCanvasGroup.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
        //difFlgとisSelectが等しくなければ、フェードを実行
		if( isSelect != difFlg )
		{
			//初期処理
			if( isSelect != difFirstFlg )
			{
				stageNameText.text = ss.stageName;
				difFirstFlg = isSelect;
			}
			FadeProcess();
		}
    }

	void FadeProcess()
	{
		//アルファ値を加算
		myCanvasGroup.alpha += Time.unscaledDeltaTime * ( fadeSpeed * ( isSelect == true ? 1 : -1 ) );
		Debug.Log( myCanvasGroup.alpha );

		//指定値に達したら
		if( isSelect == true && myCanvasGroup.alpha >= 1f )
		{
			firstButton.Select();
			myCanvasGroup.interactable = true;
			myCanvasGroup.blocksRaycasts = true;
			difFlg = isSelect;
		} else if( isSelect == false && myCanvasGroup.alpha <= 0f )
		{
			nowButton.Select();
			myCanvasGroup.interactable = false;
			myCanvasGroup.blocksRaycasts = false;
			difFlg = isSelect;
		}
	}
}
