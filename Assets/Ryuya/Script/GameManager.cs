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

	//失敗オブジェクトに配線した場合のフラグ
	private bool _isConnectFailObject = false;
	public bool isConnectFailureObject
	{
		set
		{
			_isConnectFailObject = value;
		}
		get
		{
			return _isConnectFailObject;
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

	//カメラ回転感度
	float _cameraSensitive = 5f;
	public float cameraSensitive
	{
		set
		{
			_cameraSensitive = value;
		}
		get
		{
			return _cameraSensitive;
		}
	}

	//音量
	float _soundVolume = 1f;
	public float soundVolume
	{
		set
		{
			_soundVolume = value;
		}
		get
		{
			return _soundVolume;
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

	//カメラ回転判定
	public bool canCameraRotate
	{
		get
		{
			return ( !_isPause && !_isFail && !_isClear ) ? false : true;
		}
	}

	//ステージ内スター表示フラグ
	private bool _displayStarFlg = false;
	public bool displayStarFlg
	{
		//set
		//{
		//	_displayStarFlg = value;
		//}
		get
		{
			return ( !_isClear && !_isFail && !_isPause ) ? true : false;
		}
	}

	//ステージ情報格納
	public SceneInformation sceneInformation
	{
		set; get;
	}
	
	// Start is called before the first frame update
	void Start()
    {
		DontDestroyOnLoad( this );
		//Debug.Log( LoadUserState.Instance.stageStarNum.Capacity );
		LoadUserState.Instance.Delete();
		LoadUserState.Instance.SetPlayerData( 2 );
		LoadUserState.Instance.Save();
		GameManager.Instance.soundVolume = 0.2f;
		GameManager.Instance.cameraSensitive = 5f;
    }

    // Update is called once per frame
    void Update()
    {
		PauseButtonManage();

		if( Input.GetButtonDown( "B" ) && ( nowScene == "StageSelectScene" ) )
		{
			ChangeScene( "TitleScene", false );
		}
    }

	void PauseButtonManage()
	{
		if ( _isPlaying && !_isPause && !_isClear && !_isFail && Input.GetButtonDown( "Cancel" ) && !sleepOption )
		{
			_isPause = true;
			Time.timeScale = 0f;
			Debug.Log( "in" );

			//カーソルロックの解除
			Cursor.lockState = CursorLockMode.None;
		}
		else if ( !_isPause && _sleepOption )
		{
			//タイムスケールの設定
			Time.timeScale = 1f;
			//カーソルのロック
			Cursor.lockState = CursorLockMode.Locked;

			sleepOption = false;
			Debug.Log( "out" );
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
