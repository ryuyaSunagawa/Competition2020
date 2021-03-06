﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 2.0f;   // 回転速度
    [SerializeField] private float conTurnSpeed = 2.0f;   // 回転速度
    [SerializeField] private Transform player;         // 注視対象プレイヤー

    [SerializeField] private float distance = 32.0f;    // 注視対象プレイヤーからカメラを離す距離
    [SerializeField] private Quaternion vRotation;     // カメラの垂直回転(見下ろし回転)
    [SerializeField] public Quaternion hRotation;      // カメラの水平回転
	float rotationX = 0f;

    private float scroll;   // カメラズームの取得
    int speed = 1;          // カメラズームの速度
    int zoomMax = 4, zoomMidle = 10, zoomMin = 24;  //カメラの最大,中間,最小距離
    bool isButtonFlg;       //十字キーを押したかどうかのフラグ
    int zoomNum = 1;        //3段階あるzoom距離(1-3)

    public bool startZoom;         //ゲーム開始時にズームする処理

    [SerializeField]  float scrollSpeed = 0.1f;      //スクロール速度
    float scrollTime;
    bool isScroll;

    //明かりがついたらゴールを中心にカメラを回す
    [SerializeField] Transform centerObj;
    //失敗したら失敗オブジェをみる
    [SerializeField] Transform FailureObj;

    //ゴール時に引いて回転する処理
    public bool goalZoomOut;
    bool zoomreset; //ゴール時に一定距離から始めるようにする

    void Start()
    {
        // カーソルを画面中央にロックする
        //Cursor.lockState = CursorLockMode.Locked;

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
        if ( !GameManager.Instance.canCameraRotate && startZoom) //最初のズーム処理が終わったら動かせるようになる
        {

            // カメラの回転(transform.rotation)の更新
            transform.rotation = hRotation * vRotation;

            //if ((Input.GetButtonDown("Y") || Input.GetKeyDown("z")) && isScroll)  //カメラのズームイン、ズームアウトフラグ
            //{
            //    isScroll = false; //ズームアウト
            //}
            //else if ((Input.GetButtonDown("Y") || Input.GetKeyDown("z")) && !isScroll)
            //{
            //    isScroll = true; //ズームイン
            //}

            //カメラ距離を取る
            if ((Input.GetAxis("Closs_Vertical") != 0 || Input.GetAxis("Mouse ScrollWheel") != 0) && !isButtonFlg)
            {
                zoomNum += (int)Input.GetAxis("Closs_Vertical");    //1～3で下なら-1,上なら+1
                if (Input.GetAxis("Mouse ScrollWheel") > 0) zoomNum -= 1;
                else if (Input.GetAxis("Mouse ScrollWheel") < 0) zoomNum += 1;

                if (zoomNum < 1) zoomNum = 1;
                else if (zoomNum > 3) zoomNum = 3;
                isButtonFlg = true;
            }
            else if (Input.GetAxis("Closs_Vertical") == 0) isButtonFlg = false;

            switch (zoomNum)    //カメラの距離
            {
                case 1:
                    //distance = zoomMax;
                    if(distance - zoomMax < 0) distance += 0.5f;
                    if (distance - zoomMax > 0) distance -= 0.5f;
                    break;
                case 2:
                    //distance = zoomMidle;
                    if (distance - zoomMidle < 0) distance += 0.5f;
                    if (distance - zoomMidle > 0) distance -= 0.5f;
                    break;
                case 3:
                    //distance = zoomMin;
                    if (distance - zoomMin < 0) distance += 0.5f;
                    if (distance - zoomMin > 0) distance -= 0.5f;
                    break;
            }

            //ズームの最大拡大、縮小
            //if (!isScroll)  //プレイヤー追従時のカメラ処理
            if(zoomNum <= 2)
            {
                //マウスの処理--------------------------------------------------------------------
                hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * GameManager.Instance.cameraSensitive, 0);  //垂直回転

                /*****  マウス水平回転補正処理  *****/
                float mAxisY = Input.GetAxis("Mouse Y") * turnSpeed;    //水平方向マウス移動量取得
                float mBeforeRotX = rotationX;                          //加算前回転スタック
                rotationX += mAxisY;                                    //コントローラー移動分加算
                if (rotationX >= 80f)
                {
                    float difRot = 80f - rotationX;                     //80度以上になった場合の余分回転量取得
                    rotationX += difRot;                                //余分回転量だけ回転を補正
                    mAxisY += difRot;                                   //余分回転量だけマウス移動量を補正
                }
                else if (rotationX <= 0f)
                {
                    float difRot = 0f - rotationX;                    //80度以上になった場合の余分回転量取得
                    rotationX += difRot;                                //余分回転量だけ回転を補正
                    mAxisY += difRot;                                   //余分回転量だけマウス移動料を補正
                }
                /************************************/

                vRotation *= Quaternion.Euler(mAxisY, 0, 0);  //水平回転

                //コントローラの処理--------------------------------------------------------------
                hRotation *= Quaternion.Euler(0, Input.GetAxis("R_Horizontal") * GameManager.Instance.cameraSensitive, 0);  //垂直回転

                /*****  水平回転補正処理  *****/
                float cAxisY = Input.GetAxis("R_Vertical") * conTurnSpeed;   //水平方向スティック傾斜量取得
                float cBeforeRotX = rotationX;                           //加算前回転スタック
                rotationX += cAxisY;                                     //コントローラー傾斜量分加算
                if (rotationX >= 80f)
                {
                    float difRot = 80f - rotationX;                      //80度以上になった場合の余分回転量取得
                    rotationX += difRot;                                 //余分回転量だけ回転を補正
                    cAxisY += difRot;                                    //余分回転量だけコントローラー傾斜量を補正
                }
                else if (rotationX <= 0f)
                {
                    float difRot = 0f - rotationX;                     //80度以上になった場合の余分回転量取得
                    rotationX += difRot;                                 //余分回転量だけ回転を補正
                    cAxisY += difRot;                                    //余分回転量だけコントローラー傾斜量を補正
                }
                /******************************/

                vRotation *= Quaternion.Euler(cAxisY, 0, 0);  //水平回転


                // プレイヤー中心に見回す
                transform.position = player.position + new Vector3(0, 1.5f, 0) - transform.rotation * Vector3.forward * distance;
                //if(distance > zoomMax) distance -= speed;
            }
            //else if (isScroll)  //ステージ中心に見まわしているときのカメラ処理
            else if (zoomNum >= 3)  //ステージ中心に見まわしているときのカメラ処理
            {
                //マウスの処理--------------------------------------------------------------------
                hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * GameManager.Instance.cameraSensitive, 0);  //垂直回転

                /*****  マウス水平回転補正処理  *****/
                float mAxisY = Input.GetAxis("Mouse Y") * turnSpeed;    //水平方向マウス移動量取得
                float mBeforeRotX = rotationX;                          //加算前回転スタック
                rotationX += mAxisY;                                    //コントローラー移動分加算
                if (rotationX >= 80f)
                {
                    float difRot = 80f - rotationX;                     //80度以上になった場合の余分回転量取得
                    rotationX += difRot;                                //余分回転量だけ回転を補正
                    mAxisY += difRot;                                   //余分回転量だけマウス移動量を補正
                }
                else if (rotationX <= -80f)
                {
                    float difRot = -80f - rotationX;                    //80度以上になった場合の余分回転量取得
                    rotationX += difRot;                                //余分回転量だけ回転を補正
                    mAxisY += difRot;                                   //余分回転量だけマウス移動料を補正
                }
                /************************************/

                vRotation *= Quaternion.Euler(mAxisY, 0, 0);  //水平回転

                //コントローラの処理--------------------------------------------------------------
                hRotation *= Quaternion.Euler(0, Input.GetAxis("R_Horizontal") * GameManager.Instance.cameraSensitive, 0);  //垂直回転

                /*****  水平回転補正処理  *****/
                float cAxisY = Input.GetAxis("R_Vertical") * conTurnSpeed;   //水平方向スティック傾斜量取得
                float cBeforeRotX = rotationX;                           //加算前回転スタック
                rotationX += cAxisY;                                     //コントローラー傾斜量分加算
                if (rotationX >= 80f)
                {
                    float difRot = 80f - rotationX;                      //80度以上になった場合の余分回転量取得
                    rotationX += difRot;                                 //余分回転量だけ回転を補正
                    cAxisY += difRot;                                    //余分回転量だけコントローラー傾斜量を補正
                }
                else if (rotationX <= -80f)
                {
                    float difRot = -80f - rotationX;                     //80度以上になった場合の余分回転量取得
                    rotationX += difRot;                                 //余分回転量だけ回転を補正
                    cAxisY += difRot;                                    //余分回転量だけコントローラー傾斜量を補正
                }
                /******************************/

                vRotation *= Quaternion.Euler(cAxisY, 0, 0);  //水平回転


                // ステージ中心に見回す
                transform.position = centerObj.position + new Vector3(0, 1.5f, 0) - transform.rotation * Vector3.forward * distance;
                //if(distance < zoomMin) distance += speed;
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
			if ( distance <= zoomMax )
			{
				startZoom = true;
				rotationX = transform.localEulerAngles.x;
			}
        }
        if (goalZoomOut)
        {
            if (!zoomreset) //ゴール時に距離10から引きの処理が始まる
            {
                distance = 10;
                zoomreset = true;
            }

            // player位置から距離distanceだけ手前に引いた位置を設定
            transform.position = centerObj.position + new Vector3(0, 1.5f, 0) - transform.rotation * Vector3.forward * distance;

            if (distance >= zoomMin)
            {
                //goalZoomOut = false;
                rotationX = transform.localEulerAngles.x;

                hRotation *= Quaternion.Euler(0, 0.5f, 0);  //垂直回転
                // カメラの回転(transform.rotation)の更新
                transform.rotation = hRotation * vRotation;
            }
            else
            {
                distance += 0.2f;
                vRotation = Quaternion.Euler(20, 0, 0);         //25度固定の垂直回転
                hRotation = centerObj.rotation;                    //プレイヤーの向きに合わせて初期位置変更
                // カメラの回転(transform.rotation)の更新
                transform.rotation = hRotation * vRotation;
            }
        }
        //失敗オブジェ点灯時そこをみる
        if (FailureObj.tag == "EnergizedOn")
        {
            vRotation = Quaternion.Euler(30, 0, 0);         //25度固定の垂直回転
            hRotation = FailureObj.rotation;                    //失敗オブジェクトの向きに合わせて初期位置変更
            transform.rotation = hRotation * vRotation;     //最終的なカメラの回転は、垂直回転してから水平回転する合成回転
            transform.position = FailureObj.position + new Vector3(0, 0.5f, 0) - transform.rotation * Vector3.forward * 12;
        }
    }
}