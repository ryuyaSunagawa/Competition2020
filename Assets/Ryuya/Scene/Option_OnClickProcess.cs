using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Option_OnClickProcess : MonoBehaviour
{

	//オプション画面の終了イベント
	public void SleepOption()
	{
		GameManager.Instance.sleepOption = true;
	}

	public void HideWhereUI( ReturnManager retMgr )
	{
		retMgr.isSelect = false;
	}

	public void DisplayWhereUI( ReturnManager retMgr )
	{
		retMgr.isSelect = true;
	}

	public void ChangeSelectButton( Button nextButton )
	{
		nextButton.Select();
	}

	public void BackTitleOption()
	{
		if ( GameManager.Instance.isPause == true )
		{
			SceneManager.LoadScene( "TitleScene" );
			GameManager.Instance.nowScene = "TitleScene";
			//GameManager.Instance.isPause = false;
		}
	}

	public void BackSceneSelectOption()
	{
		if ( GameManager.Instance.isPause == true )
		{
			SceneManager.LoadScene( "StageSelectScene" );
			GameManager.Instance.nowScene = "StageSelectScene";
			//GameManager.Instance.isPause = false;
		}
	}

	public void RestartButton()
	{
		GameManager.Instance.isPause = false;
		GameManager.Instance.isClear = false;
		GameManager.Instance.isFail = false;
		GameManager.Instance.isPlaying = true;
		SceneManager.LoadScene( GameManager.Instance.nowScene );
		SceneManager.LoadScene( "PauseScene", LoadSceneMode.Additive );
	}

	public void GameEnd()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		UnityEngine.Application.Quit();
	}
}
