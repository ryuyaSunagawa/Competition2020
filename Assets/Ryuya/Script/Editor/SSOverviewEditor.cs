using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor( typeof( StageSelector ) )]
public class SSEditor : Editor
{
	//bool folding = false;
	//public override void OnInspectorGUI()
	//{
	//	StageSelector ss = target as StageSelector;

	//	//EditorGUILayout.LabelField( "選択中のボタン" );
	//	//EditorGUILayout.BeginHorizontal();
	//	//ss.stageNumber = EditorGUILayout.IntField( ss.stageNumber, GUILayout.Width( 48 ) );
	//	//ss.stageName = EditorGUILayout.TextField( ss.stageName, GUILayout.Width( 48 ) );
	//	//EditorGUILayout.EndHorizontal();
	//	EditorGUILayout.LabelField( "---ステージ情報格納---", new GUIStyle() {
	//														alignment = TextAnchor.MiddleCenter,
	//														fontSize = 15
	//													} );
	//	ss.stageNumber = EditorGUILayout.IntField( "ステージ番号", 0 );
	//	ss.stageName = EditorGUILayout.TextField( "ステージ名", ss.stageName );

	//	EditorGUILayout.Space( 10 );
	//	//------ステージ概要-------//
	//	EditorGUILayout.LabelField( "選択中のボタン", new GUIStyle() {
	//													alignment = TextAnchor.MiddleCenter,
	//												  } );
	//	ss.stageSummary = EditorGUILayout.TextArea( "ステージ概要説明", ss.stageSummary );
	//	EditorGUILayout.Space( 10 );

	//	if ( folding = EditorGUILayout.Foldout( folding, "スター獲得条件欄" ) )
	//	{
	//		//------スター条件1-------//
	//		EditorGUILayout.LabelField( "スター獲得条件1" );
	//		ss.star1Text = EditorGUILayout.TextField( "ゴールライト", ss.star1Text );

	//		//------スター条件2-------//
	//		EditorGUILayout.LabelField( "スター獲得条件2" );
	//		ss.star2Text = EditorGUILayout.TextArea( "手数条件", ss.star2Text );

	//		//------スター条件3-------//
	//		EditorGUILayout.LabelField( "スター獲得条件3" );
	//		ss.star3Text = EditorGUILayout.TextArea( "ミニライトの場所と点灯説明", ss.star3Text );
	//	}
	//}
}
