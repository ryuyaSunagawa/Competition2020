using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Range( 1, 100 )] private float turnSpeed = 20.0f;   // 回転速度
    [SerializeField] private Transform player;          // 注視対象プレイヤー

    [SerializeField] private float distance = 6.0f;    // 注視対象プレイヤーからカメラを離す距離
    [SerializeField] private Quaternion vRotation;      // カメラの垂直回転(見下ろし回転)
    [SerializeField] public Quaternion hRotation;      // カメラの水平回転
    Vector3 initialVec;

    void Start()
    {
        // カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;

        // 回転の初期化
        //vRotation = Quaternion.Euler(25, 0, 0);         // 25度固定の垂直回転
        //vRotation = Quaternion.identity;         // 垂直回転(X軸を軸とする回転)
        //hRotation = Quaternion.identity;                // 水平回転(Y軸を軸とする回転)
        //transform.rotation = hRotation * vRotation;     // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転

        //// 位置の初期化
        //transform.position = player.position - transform.rotation * Vector3.forward * distance;
        turnSpeed *= 10f;
        initialVec = new Vector3(0f, 0f, distance);

    }

    void LateUpdate()
    {
        // 水平回転の更新
        //if (Input.GetMouseButton(0))
        //hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnSpeed, 0);  //垂直回転
        //vRotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * turnSpeed, 0, 0);  //水平回転

        //// カメラの回転(transform.rotation)の更新
        //transform.rotation = hRotation * vRotation;

        //// player位置から距離distanceだけ手前に引いた位置を設定
        //transform.position = player.position + new Vector3(0, 2, 0) - transform.rotation * Vector3.forward * distance;

        float xAxis = turnSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        float yAxis = turnSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

        //Debug.Log( yAxis );

        this.transform.LookAt(player);
        //水平方向回転
        transform.RotateAround(player.position, transform.up, xAxis);

        //垂直方向回転
        transform.RotateAround(player.position, transform.right, LimitRotate(yAxis));
    }

    /// <summary>
    /// 回転制御関数
    /// </summary>
    /// <param name="deltaRot">現在の回転</param>
    /// <returns></returns>
    private float LimitRotate(float deltaRot)
    {
        float whichDir = Vector3.Cross(initialVec, transform.position - player.position).x >= 0 ? 1 : -1;
        float nextRot = transform.localEulerAngles.x + deltaRot;

        if (whichDir == 1 && nextRot >= 75f)
        {
            Debug.Log(/*deltaRot - */(nextRot /*- 75f*/));
            return deltaRot - (nextRot - 75f);
        }
        else if (whichDir == -1 && nextRot <= 285f)
        {
            return deltaRot + (285f - (nextRot));
        }

        return deltaRot;
    }
}