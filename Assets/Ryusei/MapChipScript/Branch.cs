using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public int branchNum;
    public int branchRot = 0;
    bool branchFlg;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, branchRot * 90, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (branchFlg == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (branchRot >= 3) branchRot = 0;
                else branchRot += 1;

                ++branchNum;

                transform.rotation = Quaternion.Euler(0, branchRot * 90, 0);
            }
        }
        if (branchFlg == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (branchRot <= 0) branchRot = 3;
                else branchRot -= 1;

                ++branchNum;

                transform.rotation = Quaternion.Euler(0, branchRot * 90, 0);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            branchFlg = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            branchFlg = false;
        }
    }
}
