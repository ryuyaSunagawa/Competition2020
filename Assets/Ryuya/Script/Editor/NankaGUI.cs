using UnityEngine;
using UnityEditor;
 
[InitializeOnLoad]
public class NankaGUI
{
	static NankaGUI()
	{
		//SceneView.onSceneGUIDelegate += OnGUI;
	}

	private static void OnGUI( SceneView sceneView )
	{
		//Handles.BeginGUI();

		//// ボタンのサイズ
		//var ButtonWidth = 300.0f;
		//// ボタン
		//if (GUILayout.Button( "ボタン", GUILayout.Width( ButtonWidth ) ))
		//{
		//	// 押されたらダイアログを表示する
		//	EditorUtility.DisplayDialog( "ボタン押した？", "今ボタン押したよね？", "押した" );
		//}

		//Handles.EndGUI();
	}
}