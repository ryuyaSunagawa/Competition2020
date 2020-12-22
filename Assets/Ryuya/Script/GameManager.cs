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
		get
		{
			return ( !_isClear && !_isFail && !_isPause ) ? true : false;
		}
	}

	public bool[] starInfo1
	{
		get; set;
	}

	public bool[] starInfo2
	{
		get; set;
	}

	public bool[] starInfo3
	{
		get; set;
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
		if ( LoadUserState.Instance.firstGameStart )
		{
			LoadUserState.Instance.Delete();
			LoadUserState.Instance.firstGameStart = false;
			LoadUserState.Instance.SetPlayerData( 0 );
			LoadUserState.Instance.Save();
		}
		GameManager.Instance.soundVolume = 0.1f;
		GameManager.Instance.cameraSensitive = 5f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		starInfo1 = LoadUserState.Instance.gotStar1.ToArray();
		starInfo2 = LoadUserState.Instance.gotStar2.ToArray();
		starInfo3 = LoadUserState.Instance.gotStar3.ToArray();
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

			//カーソルロックの解除
			//Cursor.lockState = CursorLockMode.None;
		}
		else if ( !_isPause && _sleepOption )
		{
			//タイムスケールの設定
			Time.timeScale = 1f;
			//カーソルのロック
			//Cursor.lockState = CursorLockMode.Locked;

			sleepOption = false;
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

	public void InitializeGameFlg()
	{
		_isClear = false;
		_isFail = false;
		_isPause = false;
	}

	public void SaveClearInformation( int stageNum, int starNum )
	{
		LoadUserState.Instance.gotStar1[ stageNum ] = true;
		GameManager.Instance.starInfo1[ stageNum ] = true;
		LoadUserState.Instance.gotStar2[ stageNum ] = GameManager.Instance.starInfo2[ stageNum ];
		LoadUserState.Instance.gotStar3[ stageNum ] = GameManager.Instance.starInfo3[ stageNum ];
		LoadUserState.Instance.SetPlayerData( stageNum + 1 );
		LoadUserState.Instance.stageStarNum[ stageNum ] = starNum;
		LoadUserState.Instance.Save();
	}

	public void ResetClearInformationBuffer()
	{
		starInfo1 = LoadUserState.Instance.gotStar1.ToArray();
		starInfo2 = LoadUserState.Instance.gotStar2.ToArray();
	}

	private void OnDestroy()
	{
	}
}
