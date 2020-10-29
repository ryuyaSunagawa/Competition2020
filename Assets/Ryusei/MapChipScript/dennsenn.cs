using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dennsenn : MonoBehaviour
{
    [SerializeField] bool isDebug;
    BoxCollider[] collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponents<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (collider[0])
        {
            collider[1].enabled = false;
            collider[2].enabled = false;
            if(isDebug) Debug.Log("0がExit");
        }
        if (collider[1])
        {
            collider[0].enabled = false;
            collider[2].enabled = false;
            if (isDebug) Debug.Log("1がExit");
        }
        if (collider[2])
        {
            collider[0].enabled = false;
            collider[1].enabled = false;
            if (isDebug) Debug.Log("2がExit");
        }

        Invoke("DelayMethod", 0.02f);

        if (tag == "EnergizedOff") tag = "EnergizedOn";
        else if(tag == "EnergizedOff") tag = "EnergizedOff";
    }

    void DelayMethod()
    {
        collider[0].enabled = true;
        collider[1].enabled = true;
        collider[2].enabled = true;
    }
}
