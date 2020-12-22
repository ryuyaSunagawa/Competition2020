using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCommandController : MonoBehaviour
{
	List<KeyCode> key = new List<KeyCode>();
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void GetKey()
	{
		if ( Input.anyKeyDown )
		{
			foreach ( KeyCode code in Enum.GetValues( typeof( KeyCode ) ) )
			{
				if ( Input.GetKeyDown( code ) )
				{
					Debug.Log( code );
					key.Add( code );
				}
			}
		}
	}
}
