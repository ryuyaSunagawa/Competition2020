﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Animator anim;
    CharacterController controller;

    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Idle",true);
        anim.SetBool("Walk", false);

        if (Input.GetKey("w"))
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp("d"))
        {
            transform.Rotate(new Vector3(0, -90, 0));
        }
        if (Input.GetKeyUp("a"))
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}
