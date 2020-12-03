using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevetorDoor : MonoBehaviour
{
    private SkinnedMeshRenderer SkinnedMeshRenderer;
    Animator animator;

    int start = 0;
    bool ElectricFlg;

    Collider doorCollider;
    bool player;

    float openTime;

    void Start()
    {
        SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<Collider>();
    }

    void Update()
    {
        Debug.Log(player);
        if (player)
        {
            openTime += Time.deltaTime;
        }
        if(openTime >= 3.0f)
        {
            player = false;
            openTime = 0;
        }

        //if (start == 0)
        //{
        //    if (ElectricFlg)    //開ける
        //    {
        //        doorCollider.enabled = !doorCollider.enabled;
        //        animator.SetBool("open", true);
        //        animator.SetBool("close", false);
        //        animator.SetBool("Keepopen", false);
        //        start = 1;
        //    }
        //    else
        //    {
        //        animator.SetBool("open", false);
        //        animator.SetBool("Keepclose", true);
        //    }
        //}
        //else if (start == 1)
        //{
        //    if (!ElectricFlg || player) //閉じる
        //    {
        //        doorCollider.enabled = doorCollider.enabled;
        //        animator.SetBool("open", false);
        //        animator.SetBool("close", true);
        //        animator.SetBool("Keepclose", false);
        //        start = 0;
        //    }
        //    else
        //    {

        //        animator.SetBool("Keepopen", true);
        //        animator.SetBool("close", false);
        //    }
        //}
        if (!ElectricFlg || player)
        {
            doorCollider.enabled = doorCollider.enabled;
            animator.SetBool("open", false);
            animator.SetBool("close", true);
        }else if (ElectricFlg)
        {
            doorCollider.enabled = !doorCollider.enabled;
            animator.SetBool("open", true);
            animator.SetBool("close", false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn")
        {
            ElectricFlg = true;
        }
        else if (other.gameObject.tag == "EnergizedOff")
        {
            ElectricFlg = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = false;
        }
    }
}
