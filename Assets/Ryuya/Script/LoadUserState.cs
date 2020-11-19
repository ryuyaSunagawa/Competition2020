﻿using System.Collections;
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
	[SerializeField] public List<int> stageStarNum;		//スター獲得量

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
		Debug.Log( Application.persistentDataPath );
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
