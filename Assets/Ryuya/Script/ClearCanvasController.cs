using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearCanvasController : MonoBehaviour
{
	//クリアフラグ
	[HideInInspector] public bool clearFlg;
	//フェードフラグ
	bool fadeFlg;
	//フェードスピード
	[SerializeField, Range( 1f, 20f ), Header( "フェードスピード" )] float fadeTime = 1f;
	//クリアボタングループの有効化
	[SerializeField] ClearButtonManager clearButton;

	CanvasGroup myCanvasGroup;
	[SerializeField] Button firstButton;

	[SerializeField, Header( "ゴールライトを最初に持ってきて" )] GameObject[] starImg = new GameObject[ 3 ];

	// Start is called before the first frame update
	void Start()
    {
		//キャンバスグループ初期処理
		myCanvasGroup = GetComponent<CanvasGroup>();
		myCanvasGroup.alpha = 0f;
		myCanvasGroup.blocksRaycasts = false;
		myCanvasGroup.interactable = false;

		//クリアフラグ初期化
		clearFlg = false;
		//フェードフラグ初期化
		fadeFlg = false;
		//スターイメージの無効化
		foreach( GameObject star in starImg )
		{
			star.SetActive( false );
		}
	}

    // Update is called once per frame
    void Update()
    {
		if( clearFlg != fadeFlg )
		{
			//フェード処理
			FadeProcess();
		}
    }

	/// <summary>
	/// フェード処理
	/// </summary>
	void FadeProcess()
	{
		//キャンバスグループの透明度加算
		myCanvasGroup.alpha += Time.unscaledDeltaTime * fadeTime;

		//キャンバスグループ有効化が完了したら
		if( myCanvasGroup.alpha >= 1 )
		{
			Debug.Log( "ahan" );
			//クリアボタングループの有効化
			clearButton.changing = true;
			//Invoke( "RaiseFrag", 0.5f );
			//フェード処理終了
			fadeFlg = clearFlg;
			//キャンバスグループのレイキャスト有効化
			myCanvasGroup.blocksRaycasts = true;
			myCanvasGroup.interactable = true;
		}
	}

	void RaiseFrag()
	{
		//クリアボタングループのフェード処理
		clearButton.changing = true;
	}

	/// <summary>
	/// クリア時の評価
	/// </summary>
	/// <param name="gotStar"></param>
	public void ClearRate( int gotStar )
	{
		//starの数にあわせて星の画像表示
		for ( int i = 0; i < gotStar; i++ )  
		{
			starImg[ i ].SetActive( true );
		}

		//カーソルのロック解除
		Cursor.lockState = CursorLockMode.None;
		//クリアフラグ有効化
		clearFlg = true;
		GameManager.Instance.isClear = true;
	}
}
