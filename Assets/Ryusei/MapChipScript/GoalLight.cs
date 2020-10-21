using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (other.gameObject.tag == "EnergizedOff")
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
