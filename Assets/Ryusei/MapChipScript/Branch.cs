using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public int branchNum;
    public int branchRot = 0;
    bool branchFlg;

    AudioSource audioSource;

    int changeColor;
    int beforeColor;

    MeshRenderer meshRenderer;//
    bool MatChange = false;//
    [SerializeField] Material[] materials1;//
    [SerializeField] Material[] materials2;//

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, branchRot * 90, 0);

        audioSource = gameObject.GetComponent<AudioSource>();

        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (branchFlg == true && (!GameManager.Instance.isClear && !GameManager.Instance.isFail))
        {
            if (Input.GetButtonDown("RB"))
            {
                audioSource.Play();
                if (branchRot >= 3) branchRot = 0;
                else branchRot += 1;

                ++branchNum;

                transform.rotation = Quaternion.Euler(0, branchRot * 90, 0);
            }
            if (Input.GetButtonDown("LB"))
            {
                audioSource.Play();
                if (branchRot <= 0) branchRot = 3;
                else branchRot -= 1;

                ++branchNum;

                transform.rotation = Quaternion.Euler(0, branchRot * 90, 0);
            }
        }

        if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                MatChange = false;
            }
            else
            {
                MatChange = true;
            }
        }
        beforeColor = changeColor;
        meshRenderer.materials = MatChange ? materials2 : materials1;//
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            branchFlg = true;
            changeColor = 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            branchFlg = false;
            changeColor = 0;
        }
    }
}
