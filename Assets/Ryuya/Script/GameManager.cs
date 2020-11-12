using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	//private void Awake()
	//{
	//	DontDestroyOnLoad( this );
	//}

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
			_isPause = value;
		}
		get
		{
			return _isPause;
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

	// Start is called before the first frame update
	void Start()
    {
		DontDestroyOnLoad( this );
		LoadUserState.Instance.Save();
    }

    // Update is called once per frame
    void Update()
    {
		PauseButtonManage();
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
			print( "OK" );
		}
	}
}
