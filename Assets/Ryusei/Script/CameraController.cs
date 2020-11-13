using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 1.0f;   // 回転速度
    [SerializeField] private Transform player;         // 注視対象プレイヤー

    [SerializeField] private float distance = 32.0f;    // 注視対象プレイヤーからカメラを離す距離
    [SerializeField] private Quaternion vRotation;     // カメラの垂直回転(見下ろし回転)
    [SerializeField] public Quaternion hRotation;      // カメラの水平回転

    private float scroll;   // カメラズームの取得
    int speed = 1;          // カメラズームの速度
    int zoomMax = 4, zoomMin = 32;  //カメラの最大、最小距離

    public bool startZoom;         //ゲーム開始時にズームする処理

    [SerializeField]  float scrollSpeed = 0.1f;      //スクロール速度
    float scrollTime;
    bool isScroll;

    void Start()
    {
        // カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;

        // 回転の初期化
        vRotation = Quaternion.Euler(30, 0, 0);         //25度固定の垂直回転
        hRotation = player.rotation;                    //プレイヤーの向きに合わせて初期位置変更
        //vRotation = Quaternion.identity;              //垂直回転(X軸を軸とする回転)
        //hRotation = Quaternion.identity;                //水平回転(Y軸を軸とする回転)
        transform.rotation = hRotation * vRotation;     //最終的なカメラの回転は、垂直回転してから水平回転する合成回転

        // 位置の初期化
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }

    void LateUpdate()
    {
        if (startZoom) //最初のズーム処理が終わったら動かせるようになる
        {
            // 水平回転の更新

            //マウスの処理--------------------------------------------------------------------
            hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnSpeed, 0);  //垂直回転
            vRotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * turnSpeed, 0, 0);  //水平回転
            //コントローラの処理--------------------------------------------------------------
            hRotation *= Quaternion.Euler(0, Input.GetAxis("R_Horizontal") * turnSpeed, 0);  //垂直回転
            vRotation *= Quaternion.Euler(Input.GetAxis("R_Vertical") * turnSpeed, 0, 0);  //水平回転

            // カメラの回転(transform.rotation)の更新
            transform.rotation = hRotation * vRotation;

            // player位置から距離distanceだけ手前に引いた位置を設定
            transform.position = player.position + new Vector3(0, 1.5f, 0) - transform.rotation * Vector3.forward * distance;

            // マウスホイールの処理----------------------
            scroll = Input.GetAxis("Mouse ScrollWheel");

            //コントローラの処理------------------------
            if (isScroll) // 次のボタンが押せるまでのインターバル
            {
                scrollTime += Time.deltaTime;
                if (scrollTime >= 0.025f)
                {
                    isScroll = false;
                    scrollTime = 0;
                }
            }

            if (!isScroll && Input.GetAxis("Closs_Vertical") != 0)
            {
                scroll = -Input.GetAxis("Closs_Vertical") * scrollSpeed;
                isScroll = true;
            }

            //ズームの最大拡大、縮小
            if (scroll > 0 && distance > zoomMax)
            {
                distance -= speed;
                scroll = 0;
            }
            else if (scroll < 0 && distance < zoomMin)
            {
                distance += speed;
                scroll = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!startZoom)
        {
            distance -= 0.2f;
            // player位置から距離distanceだけ手前に引いた位置を設定
            transform.position = player.position + new Vector3(0, 1.5f, 0) - transform.rotation * Vector3.forward * distance;
            if (distance <= zoomMax) startZoom = true;
        }
    }
}