﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if( Input.GetKeyDown( KeyCode.D ) )
		{
			//transform.Rotate( transform.up, 90 );
			transform.RotateAround( transform.root.position, new Vector3( 0f, 0f, 1f ), 90 );
		}
    }
}
