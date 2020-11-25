﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSOButtonController : MonoBehaviour
{
    public void CancelClicked( SSOverviewManager ssom )
	{
		ssom.isSelect = false;
	}

	public void StartClicked( SSOverviewManager ssom )
	{
		SceneManager.LoadScene( ssom.ss.stageSceneName );
		GameManager.Instance.nowScene = ssom.ss.stageSceneName;
		if ( ssom.ss.stageSceneName != "StageSelectScene" && ssom.ss.stageSceneName != "TitleScene" )
		{
			SceneManager.LoadScene( "PauseScene", LoadSceneMode.Additive );
			GameManager.Instance.isPlaying = true;
		}
	}
}
