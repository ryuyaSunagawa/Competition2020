using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_PowerButton2 : MonoBehaviour
{
    public bool SwitchFlg;         //スイッチが押されているかいないか
    bool SwitchHitFlg;
    BoxCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SwitchHitFlg == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (SwitchFlg == false)
                {
                    this.gameObject.transform.Translate(0, -0.1f, 0);
                    this.tag = "EnergizedOn";
                    SwitchFlg = true;
                }
                else
                {
                    this.gameObject.transform.Translate(0, 0.1f, 0);
                    this.tag = "EnergizedOff";
                    SwitchFlg = false;
                }
            }
        }
    }

    void DelayMethod()
    {
        collider.size = new Vector3(2, 2, 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")   //プレイヤーが触れたらSwitchHitFlgをOn
        {
            SwitchHitFlg = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")   //プレイヤーが離れたらSwitchHitFlgをOff
        {
            SwitchHitFlg = false;
        }
    }
}
