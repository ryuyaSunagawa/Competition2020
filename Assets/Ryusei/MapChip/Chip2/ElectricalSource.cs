﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleyOn", 0.02f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeleyOn()
    {
        tag = "EnergizedOn";
    }
}
