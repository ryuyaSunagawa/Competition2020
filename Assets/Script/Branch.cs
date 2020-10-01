using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{

    public int BranchRot = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("z"))
            {
                if (BranchRot >= 3) BranchRot = 0;
                else BranchRot += 1;

                transform.rotation = Quaternion.Euler(0, BranchRot * 90, 0);
                Debug.Log(BranchRot);
            }
        }
    }
}
