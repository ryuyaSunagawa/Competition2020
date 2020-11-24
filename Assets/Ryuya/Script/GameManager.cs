using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	//プレイ中か
	bool _isPlaying = false;
	public bool isPlaying
	{
		set
		{
			_isPlaying = value;
		}
		get
		{
			return _isPlaying;
		}
	}

	//オプションボタンフラグ
	bool _isPause = false;
	public bool isPause
	{
		set
		{
			if( !isFail && !isClear )	_isPause = value;
		}
		get
		{
			return _isPause;
		}
	}

	//失敗フラグ
	bool _isFail = false;
	public bool isFail
	{
		set
		{
			_isFail = value;
		}
		get
		{
			return _isFail;
		}
	}

	//クリア画面フラグ
	bool _isClear = false;
	public bool isClear
	{
		set
		{
			_isClear = value;
		}
		get
		{
			return _isClear;
		}
	}

	//オプションへ戻るボタン
	bool _sleepOption = false;
	public bool sleepOption
	{
		set
		{
			_sleepOption = value;
		}
		get
		{
			return _sleepOption;
		}
	}
	
	//シーン
	string _nowScene = "TitleScene";
	public string nowScene
	{
		set
		{
			_nowScene = value;
		}
		get
		{
			return _nowScene;
		}
	}

	public bool canCameraRotate
	{
		get
		{
			return ( !_isPause && !_isFail && !_isClear ) ? false : true;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		DontDestroyOnLoad( this );
		//Debug.Log( LoadUserState.Instance.stageStarNum.Capacity );
		LoadUserState.Instance.Delete();
		LoadUserState.Instance.SetPlayerData( 1 );
		LoadUserState.Instance.Save();
    }

    // Update is called once per frame
    void Update()
    {
		PauseButtonManage();

		if( Input.GetButtonDown( "A" ) && ( nowScene == "StageSelectScene" ) )
		{
			ChangeScene( "TitleScene", false );
		}
    }

	void PauseButtonManage()
	{
		if ( _isPlaying && !_isPause && Input.GetButtonDown( "Cancel" ) )
		{
			_isPause = true;
			Time.timeScale = 0f;

			//カーソルロックの解除
			Cursor.lockState = CursorLockMode.None;
		}
		else if ( _isPlaying && _isPause && ( Input.GetButtonDown( "Cancel" ) || sleepOption ) )
		{
			_isPause = false;
			Time.timeScale = 1f;
			sleepOption = false;

			//カーソルのロック
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	public void ChangeScene( string stageName, bool wantAddPause )
	{
		SceneManager.LoadScene( stageName );
		if ( wantAddPause ) SceneManager.LoadScene( "Pause", LoadSceneMode.Additive );
		nowScene = stageName;
	}

	public void ChangeScene( int stageNumber, bool wantAddPause )
	{
		SceneManager.LoadScene( stageNumber );
		if( wantAddPause )	SceneManager.LoadScene( "Pause", LoadSceneMode.Additive );
		nowScene = SceneManager.GetSceneByBuildIndex( stageNumber ).name;
	}

	public int CheckPauseStarting()
	{
		int scene = SceneManager.sceneCount;
		int count = 0;
		for ( int i = 0; i < scene; i++ )
		{
			if ( SceneManager.GetSceneAt( i ).name == "PauseScene" )
			{
				count++;
			}
		}

		return count;
	}

	private void OnDestroy()
	{
	}
}
