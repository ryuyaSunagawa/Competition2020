using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneInformation
{
	//シーンナンバー(1から)
	public int stageNumber;
	//シーン名
	public string stageName;
	//ステージのシーン名
	public string stageSceneName;
	//ステージ概要
	public string stageSummary;
	//スター獲得条件1
	public string star1Text;
	//スター獲得条件2
	public string star2Text;
	//スター獲得条件3
	public string star3Text;
}