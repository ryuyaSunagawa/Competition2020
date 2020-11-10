using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{
	[SerializeField, Header( "ステージ番号" )] int stageNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( LoadUserState.Instance.GetProgress() + 1 >= stageNumber )
		{
			this.GetComponent<Button>().interactable = true;
			//Debug.Log( LoadUserState.Instance.GetProgress() );
		}
    }
}
