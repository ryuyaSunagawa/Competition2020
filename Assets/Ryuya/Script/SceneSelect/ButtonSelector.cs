using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelector : MonoBehaviour
{
	public void ButtonClicked( string sceneName )
	{
		SceneManager.LoadScene( sceneName );
		GameManager.Instance.nowScene = sceneName;
		if( sceneName != "StageSelectScene" && sceneName != "TitleScene" )
		{
			SceneManager.LoadScene( "PauseScene", LoadSceneMode.Additive );
			GameManager.Instance.isPlaying = true;
		}
	}

	public void Fail_Retry()
	{
		SceneManager.LoadScene( GameManager.Instance.nowScene );
		SceneManager.LoadScene( "PauseScene", LoadSceneMode.Additive );
		GameManager.Instance.isPlaying = true;
		GameManager.Instance.isFail = false;
		GameManager.Instance.isPause = false;
		GameManager.Instance.isClear = false;
	}

	public void Fail_DisplayWhereBack( ReturnManager retMgr )
	{
		retMgr.isSelect = true;
	}

	public void Fail_LeaveOff( string sceneName )
	{
		SceneManager.LoadScene( sceneName );
		GameManager.Instance.isPlaying = false;
		GameManager.Instance.isFail = false;
		GameManager.Instance.isClear = false;
		GameManager.Instance.isPause = false;
		GameManager.Instance.nowScene = sceneName;
	}

	public void ChangeNextStage()
	{
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
		SceneManager.LoadScene( "PauseScene", LoadSceneMode.Additive );
		GameManager.Instance.isPlaying = true;
		GameManager.Instance.isFail = false;
		GameManager.Instance.isClear = false;
		GameManager.Instance.isPause = false;
	}

	public void EndButtonClicked()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		UnityEngine.Application.Quit();
	}
}
