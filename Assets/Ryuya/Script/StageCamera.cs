using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCamera : MonoBehaviour
{
	//Camera myCam;
	Transform verTransform = null;
	Transform horTransform = null;
	[SerializeField] Transform centerObj;
	[SerializeField, Range( 0f, 1000f )] float speed = 10f;

	Vector3 initialVec = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
		initialVec = transform.position - centerObj.position;
		//myCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		float xAxis = speed * Input.GetAxis( "Mouse X" ) * Time.deltaTime;
		float yAxis = speed * Input.GetAxis( "Mouse Y" ) * Time.deltaTime;

		this.transform.LookAt( centerObj );
		//水平方向回転
		transform.RotateAround( centerObj.position, transform.up, xAxis );

		//垂直方向回転(制御系)

		transform.RotateAround( centerObj.position, transform.right, yAxis );

		Debug.Log( transform.eulerAngles + ", " + transform.localEulerAngles );
		//Debug.Log( Vector3.Cross( initialVec, transform.position - centerObj.position ) );
		//Debug.Log( LimitRotate( yAxis ) );
	}

	private void OnDrawGizmos()
	{
		Vector3 ahan1 = transform.position + transform.right;
		Gizmos.color = Color.green;
		Gizmos.DrawLine( transform.position, ahan1 );
		//Debug.Log( "dist: " + Vector3.Distance( transform.position, transform.position + transform.right ) );
	}

	/// <summary>
	/// 回転制御関数
	/// </summary>
	/// <param name="rot">現在のオブジェクトの回転</param>
	/// <param name="deltaRot">現在の回転</param>
	/// <returns></returns>
	private float LimitRotate( float deltaRot )
	{
		float whichDir = Vector3.Cross( initialVec, transform.position - centerObj.position ).x > 0 ? 1 : -1;

		if( whichDir == 1 && transform.localEulerAngles.x + deltaRot >= 75f )
		{
			return deltaRot - (transform.localEulerAngles.x + deltaRot - 75f );
		}
		else if( whichDir == -1 && transform.localEulerAngles.x - deltaRot <= 285f )
		{

			return deltaRot;
		}

		return whichDir;

		//if( ( rot.x > 1 ) && ( rot.x + deltaRot ) >= 75f )
		//{
			
		//	return 75f;
		//} else if( ( rot.x < 0 ) && ( rot.x + deltaRot ) <= 265f )
		//{
		//	return 265f;
		//}

		//return rot.x + deltaRot;
	}
}
