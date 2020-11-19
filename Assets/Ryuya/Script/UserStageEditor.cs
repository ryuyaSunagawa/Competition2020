using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class UserStageEditor
{
    [MenuItem( "Profile/Delete Profile" )]
	static void DeleteProfile()
	{
		LoadUserState.Instance.Delete();
	}
}
