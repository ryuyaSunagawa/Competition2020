﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public bool SwitchFlg;         //スイッチが押されているかいないか
    bool SwitchHitFlg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SwitchHitFlg == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (SwitchFlg == false)
                {
                    this.gameObject.transform.Translate(0, -0.1f, 0);
                    SwitchFlg = true;
                    Debug.Log("スイッチオン");
                }
                else
                {
                    this.gameObject.transform.Translate(0, 0.1f, 0);
                    SwitchFlg = false;
                    Debug.Log("スイッチオフ");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SwitchHitFlg = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SwitchHitFlg = false;
        }
    }

}
