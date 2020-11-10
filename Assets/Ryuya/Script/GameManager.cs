using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	//private void Awake()
	//{
	//	DontDestroyOnLoad( this );
	//}

	// Start is called before the first frame update
	void Start()
    {
		DontDestroyOnLoad( this );
		LoadUserState.Instance.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
