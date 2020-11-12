using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEdit_Pumpkin: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay( Collider other )
	{
		if( other.gameObject.tag == "EnergizedOn" )
		{
			GetComponentInChildren<Light>().enabled = true;
		}
	}
}
