using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 direction = cameraForward * Input.GetAxis("Vertical") +
                Camera.main.transform.right * Input.GetAxis("Horizontal");

        transform.position += direction / 100;

        //if (Input.GetKey("w"))
        //{
        //    transform.position -= transform.right * speed * Time.deltaTime;
        //}
        //if (Input.GetKey("s"))
        //{
        //    transform.position += transform.right * speed * Time.deltaTime;
        //}
        //if (Input.GetKey("d"))
        //{
        //    transform.position += transform.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey("a"))
        //{
        //    transform.position -= transform.forward * speed * Time.deltaTime;
        //}
    }
}
