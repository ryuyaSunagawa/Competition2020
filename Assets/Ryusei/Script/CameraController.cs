using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject mainCamera;  //カメラ
    //GameObject fieldObject; //フィールド
    [SerializeField] GameObject Player;
    public float rotateSpeed = 3.0f; //回転スピード

    void Start()
    {
        this.mainCamera = Camera.main.gameObject; //カメラオブジェクトを代入
        //this.fieldObject = GameObject.Find("Player");
        //this.fieldObject = GameObject.Find("Floor1");
    }
    void Update()
    {
            rotateCamera();
    }
    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * this.rotateSpeed, Input.GetAxis("Mouse Y") * this.rotateSpeed, 0);
        this.mainCamera.transform.RotateAround(Player.transform.position, Vector3.up, angle.x);
        this.mainCamera.transform.RotateAround(Player.transform.position, transform.right, angle.y);
    }
}