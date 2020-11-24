using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Option_OnClickProcess : MonoBehaviour
{
	[SerializeField] Image panelImg;
	[SerializeField] Text whereText;
	[SerializeField] Button titleButton;
	[SerializeField] Button sselectButton;
	[SerializeField] Button cancelButton;

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

	public void BackSelectOption()
	{
		whereText.color = new Color( 0, 0, 0, 255 );
		whereText.enabled = true;
		panelImg.color = new Color( 255, 255, 255, 255 );
		panelImg.enabled = true;
		titleButton.image.color = new Color( 255, 255, 255, 255 );
		titleButton.enabled = true;
		titleButton.GetComponentInChildren<Text>().color = new Color( 0, 0, 0, 255 );
		sselectButton.image.color = new Color( 255, 255, 255, 255 );
		sselectButton.enabled = true;
		sselectButton.GetComponentInChildren<Text>().color = new Color( 0, 0, 0, 255 );
		cancelButton.image.color = new Color( 255, 255, 255, 255 );
		cancelButton.enabled = true;
		cancelButton.GetComponentInChildren<Text>().color = new Color( 0, 0, 0, 255 );
	}

	public void CancelOption()
	{
		whereText.color = new Color( 0, 0, 0, 0 );
		whereText.enabled = false;
		panelImg.color = new Color( 255, 255, 255, 0 );
		panelImg.enabled = false;
		titleButton.image.color = new Color( 255, 255, 255, 0 );
		titleButton.enabled = false;
		titleButton.GetComponentInChildren<Text>().color = new Color( 255, 255, 255, 0 );
		sselectButton.image.color = new Color( 255, 255, 255, 0 );
		sselectButton.enabled = false;
		sselectButton.GetComponentInChildren<Text>().color = new Color( 255, 255, 255, 0 );
		cancelButton.image.color = new Color( 255, 255, 255, 0 );
		cancelButton.enabled = false;
		cancelButton.GetComponentInChildren<Text>().color = new Color( 255, 255, 255, 0 );
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
