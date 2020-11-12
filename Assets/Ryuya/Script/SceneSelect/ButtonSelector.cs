using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ButtonClicked( string sceneName )
	{
		SceneManager.LoadScene( sceneName );
		GameManager.Instance.nowScene = sceneName;
		if( sceneName != "StageSelectScene" && sceneName != "TitleScene" )
		{
			SceneManager.LoadScene( "PauseScene", LoadSceneMode.Additive );
		}
		GameManager.Instance.isPlaying = true;
	}

	public void ButtonClicked_End()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		UnityEngine.Application.Quit();
	}
}
