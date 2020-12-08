using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEditor;

[Serializable]
public class LoadUserState : ISerializationCallbackReceiver
{

	private static LoadUserState _instance = null;
	public static LoadUserState Instance
	{
		get
		{
			if( _instance == null )
			{
				Load();
			}
			return _instance;
		}
	}

	[SerializeField] private static string _jsonText = "";

	//保存されるデータ群
	[SerializeField] public int progressedStageNum;		//ステージ進行度
	[SerializeField] public int stageVolume;			//ステージ数
	[SerializeField] public List<int> stageStarNum = new List<int>(6) { 0, 0, 0, 0, 0, 0 };		//スター獲得量
	[SerializeField] public List<bool> gotStar1 = new List<bool>(6) { false, false, false, false, false, false };		//スター獲得量
	[SerializeField] public List<bool> gotStar2 = new List<bool>(6) { false, false, false, false, false, false };		//スター獲得量
	[SerializeField] public List<bool> gotStar3 = new List<bool>(6) { false, false, false, false, false, false };       //スター獲得量

	//[Serializable]
	//public struct StageInformation
	//{
	//	public int stageNumber;
	//	public string stageName;
	//	public string stageSceneName;
	//	public string stageSummary;
	//	public string star1Text;
	//	public string star2Text;
	//	public string star3Text;
	//};

	[SerializeField]
	public List<SceneInformation> stageInfo = new List<SceneInformation>( 3 ) {
		new SceneInformation{
			stageNumber = 1,
			stageName = "ハロウィン",
			stageSceneName = "Halloween" ,
			stageSummary = "ハロウィンの会場に灯りをともそう!",
			star1Text = "お城に灯りをともす",
			star2Text = "5つあるかぼちゃに灯りをともそう",
			star3Text = "回転盤を?回転以内でクリア"
		},
		new SceneInformation{
			stageNumber = 2,
			stageName = "秋祭り",
			stageSceneName = "Akimaturi" ,
			stageSummary = "お祭りの会場に灯りをともそう!",
			star1Text = "右の大きい屋台に灯りをともす",
			star2Text = "左の小さい屋台2つに灯りをともす",
			star3Text = "回転盤を?回転以内でクリア"
		},
		new SceneInformation{
			stageNumber = 3,
			stageName = "クリスマス",
			stageSceneName = "Christmas" ,
			stageSummary = "クリスマスの会場に灯りをともそう!",
			star1Text = "クリスマスツリーに灯りをともす",
			star2Text = "小さな雪だるまに灯りをともす",
			star3Text = "回転盤を?回転以内でクリア"
		},
	};

	//[SerializeField] public List<StageSelector> stageInformation = new List<StageSelector>( 3 )
	//{
	//	new StageSelector{
	//		stageNumber = 1,
	//		stageName = "ハロウィン",
	//		stageSceneName = "Halloween" ,
	//		stageSummary = "ハロウィンの会場に灯りをともそう!",
	//		star1Text = "お城に灯りをともす",
	//		star2Text = "5つあるかぼちゃに灯りをともそう",
	//		star3Text = "回転盤を?回転以内でクリア"
	//	},
	//	new StageSelector{
	//		stageNumber = 2,
	//		stageName = "秋祭り",
	//		stageSceneName = "Akimaturi" ,
	//		stageSummary = "お祭りの会場に灯りをともそう!",
	//		star1Text = "右の大きい屋台に灯りをともす",
	//		star2Text = "左の小さい屋台2つに灯りをともす",
	//		star3Text = "回転盤を?回転以内でクリア"
	//	},
	//	new StageSelector{
	//		stageNumber = 3,
	//		stageName = "クリスマス",
	//		stageSceneName = "Christmas" ,
	//		stageSummary = "クリスマスの会場に灯りをともそう!",
	//		star1Text = "クリスマスツリーに灯りをともす",
	//		star2Text = "小さな雪だるまに灯りをともす",
	//		star3Text = "回転盤を?回転以内でクリア"
	//	},
	//};

	//[SerializeField] public StageSelector ss = new StageSelector();
	//[SerializeField] public StageSelector ss = new StageSelector{ stageName = "ahan" };

	//-------------------------------------------
	//シリアライズ・デシリアライズ時コールバック
	//-------------------------------------------

	/// <summary>
	/// json->Loadに変換された後に実行

	/// </summary>
	public void OnAfterDeserialize()
	{
	}

	/// <summary>
	/// Load->Jsonに変換される前に実行
	/// </summary>
	public void OnBeforeSerialize()
	{
	}

	/// <summary>
	/// 引数のオブジェクトをシリアライズして返す
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="obj"></param>
	/// <returns></returns>
	private static string Serialize<T>( T obj )
	{
		var binFormat = new BinaryFormatter();
		var memStream = new MemoryStream();
		binFormat.Serialize( memStream, obj );
		return Convert.ToBase64String( memStream.GetBuffer() );
	}

	/// <summary>
	/// 引数のテキストを指定されたクラスにデシリアライズする
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="str"></param>
	/// <returns></returns>
	private static T DeSerialize<T>( string str )
	{
		var binFormat = new BinaryFormatter();
		var memStream = new MemoryStream( Convert.FromBase64String( str ) );
		return (T)binFormat.Deserialize( memStream );
	}

	//----------------------------
	//  取得
	//----------------------------

	/// <summary>
	/// データ再読み込み
	/// </summary>
	public void Reload()
	{
		JsonUtility.FromJsonOverwrite( GetJson(), this );
	}

	/// <summary>
	/// ローディング処理
	/// </summary>
	static void Load()
	{
		_instance = JsonUtility.FromJson<LoadUserState>( GetJson() ); 
	}

	/// <summary>
	/// Jsonファイルの読み込み
	/// </summary>
	/// <returns></returns>
	private static string GetJson()
	{
		if( !string.IsNullOrEmpty( _jsonText ) )
		{
			return _jsonText;
		}

		string filePath = GetSaveFilePath();

		if( File.Exists( filePath ) )
		{
			_jsonText = File.ReadAllText( filePath );
		} else
		{
			_jsonText = JsonUtility.ToJson( new LoadUserState() );
		}
		return _jsonText;
	}

	//--------------------------
	//  保存
	//--------------------------

	/// <summary>
	/// データをJson化し保存
	/// </summary>
	public void Save()
	{
		_jsonText = JsonUtility.ToJson( this );
		File.WriteAllText( GetSaveFilePath(), _jsonText );
	}

	//--------------------------
	//  削除
	//--------------------------

	/// <summary>
	/// データを全て削除し、初期化する
	/// </summary>
	public void Delete()
	{
		_jsonText = JsonUtility.ToJson( new LoadUserState() );
		Reload();
	}

	/// <summary>
	/// Jsonファイルパスの取得
	/// </summary>
	/// <returns></returns>
	private static string GetSaveFilePath()
	{
		string filePath = "LoadUserState";

#if UNITY_EDITOR
		filePath += ".json";
#else
		filePath = Application.persistentDataPath + "/" + filePath;
#endif
		//Debug.Log( Application.persistentDataPath );
		return filePath;
	}

	/// <summary>
	/// プレイヤーの進捗度ステージ数を返します
	/// </summary>
	/// <returns>ステージ番号(int型)</returns>
	public int GetProgress()
	{
		return progressedStageNum;
	}

	public void SetPlayerData( int num )
	{
		if( progressedStageNum < num )
		{
			progressedStageNum = num;
		}
	}

	public void SetStarNum( int stageNumber, int starNum )
	{
		stageStarNum[ stageNumber ] = starNum;
	}
}
