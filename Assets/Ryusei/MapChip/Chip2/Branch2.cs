using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch2 : MonoBehaviour
{
    GameObject powerSupply;
    BoxCollider powerSupplyCollider;
    public int BranchRot = 0;
    bool BranchFlg;

    // Start is called before the first frame update
    void Start()
    {
        powerSupply = GameObject.FindGameObjectWithTag("PowerButton");
        powerSupplyCollider = powerSupply.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (BranchFlg == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (BranchRot >= 3) BranchRot = 0;
                else BranchRot += 1;

                transform.rotation = Quaternion.Euler(0, BranchRot * 90, 0);

                powerSupplyCollider.enabled = false;
                Invoke("ColliderTrue", 0.02f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BranchFlg = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BranchFlg = false;
        }
    }

    void ColliderTrue()
    {
        powerSupplyCollider.enabled = true;
    }
}
