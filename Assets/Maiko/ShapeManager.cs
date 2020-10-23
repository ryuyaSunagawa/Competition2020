using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    private SkinnedMeshRenderer SkinnedMeshRenderer;
    Animator animator;

    int start = 0;

    // Start is called before the first frame update
    void Start()
    {
        SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start == 0)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                //SkinnedMeshRenderer.SetBlendShapeWeight(0, 100f);
                animator.SetBool("open", true);
                animator.SetBool("close", false);
                animator.SetBool("Keepopen", false);
                start = 1;
            }
            else
            {
                //SkinnedMeshRenderer.SetBlendShapeWeight(0, 0f);
                animator.SetBool("open", false);
                animator.SetBool("Keepclose", true);
            }
        }else if (start == 1)
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                //SkinnedMeshRenderer.SetBlendShapeWeight(0, 100f);
                animator.SetBool("open", false);
                animator.SetBool("close", true);
                animator.SetBool("Keepclose", false);
                start = 0;
            }
            else
            {
                //SkinnedMeshRenderer.SetBlendShapeWeight(0, 0f);
                animator.SetBool("Keepopen", true);
                animator.SetBool("close", false);
            }
        }

    }
}
