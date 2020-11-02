using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCamera : MonoBehaviour
{
	//Camera myCam;
	Transform verTransform = null;
	Transform horTransform = null;
	[SerializeField] Transform centerObj;
	[SerializeField, Range( 0, 100 )] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
		//myCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		//Vector3 nextPos = new Vector3();
		this.transform.LookAt( centerObj );
		this.transform.RotateAround( centerObj.position, transform.up, speed * Input.GetAxis( "Mouse X" ) );
		//float angleBetween
	}
}
