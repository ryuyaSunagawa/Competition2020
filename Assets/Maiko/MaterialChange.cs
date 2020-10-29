using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    MeshRenderer meshRenderer;
    bool MatChange = false;
    [SerializeField] Material[] materials1;
    [SerializeField] Material[] materials2;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            MatChange = true;
            
        }else if (Input.GetKey(KeyCode.Alpha8))
        {
            MatChange = false;
        }
        meshRenderer.materials = MatChange ? materials2 : materials1;
    }
}
