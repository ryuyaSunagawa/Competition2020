using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCamera : MonoBehaviour
{
	Transform verTransform = null;
	Transform horTransform = null;
	[SerializeField] Transform centerObj;
	[SerializeField, Range( 0, 100 )] float speed = 10f;
	[SerializeField, Header( "中心からのカメラの距離" )] float centerDistance = 10f;
	float beforeCD = 10f;
	[SerializeField, Header( "シーンビュー内でカメラが中点を向くか" )] bool beTargetCenter = true;
	Vector3 initialVec = new Vector3();

	private void Awake()
	{
		speed *= 10f;
	}

	// Start is called before the first frame update
	void Start()
    {
		initialVec = ( new Vector3( 0f, 0f, -10f ) * centerDistance ) - centerObj.position;
		//中心からの距離を計算し、代入
		//transform.position = ( transform.position - centerObj.position ).normalized * centerDistance;
    }

    // Update is called once per frame
    void Update()
    {
		float xAxis = speed * Input.GetAxis( "Mouse X" ) * Time.deltaTime;
		float yAxis = speed * Input.GetAxis( "Mouse Y" ) * Time.deltaTime;

		//Debug.Log( yAxis );

		this.transform.LookAt( centerObj );
		//水平方向回転
		transform.RotateAround( centerObj.position, transform.up, xAxis );

		//垂直方向回転
		transform.RotateAround( centerObj.position, transform.right, LimitRotate( yAxis ) );
	}

	private void OnDrawGizmos()
	{
		if( beTargetCenter ) transform.LookAt( centerObj );
		//transform.position = ( transform.position - centerObj.position ).normalized * centerDistance;
		Debug.Log( ( transform.position - centerObj.position ).normalized * centerDistance );
		Gizmos.color = Color.green;
		Gizmos.DrawLine( centerObj.position, transform.position.normalized * centerDistance );
	}

	/// <summary>
	/// 回転制御関数
	/// </summary>
	/// <param name="deltaRot">現在の回転</param>
	/// <returns></returns>
	private float LimitRotate( float deltaRot )
	{
		float whichDir = Vector3.Cross( initialVec, transform.position - centerObj.position ).x >= 0 ? 1 : -1;
		float nextRot = transform.localEulerAngles.x + deltaRot;

		if ( whichDir == 1 && nextRot >= 75f ) 
		{
			Debug.Log( deltaRot - ( nextRot - 75f ) );
			return deltaRot - ( nextRot - 75f );
		}
		else if ( whichDir == -1 && nextRot <= 285f ) 
		{
			return deltaRot + ( 285f - ( nextRot ) );
		}

		return deltaRot;
	}
}
