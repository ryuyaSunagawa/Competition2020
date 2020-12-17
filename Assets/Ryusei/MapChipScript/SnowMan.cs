using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan : MonoBehaviour
{
    int changeColor;
    int beforeColor;

    public bool hasLight;

    MeshRenderer meshRenderer;//
    bool MatChange = false;//
    [SerializeField] Material[] materials1;//
    [SerializeField] Material[] materials2;//

    int childCount; //子オブジェクトの数
    [SerializeField] GameObject[] childObject;

    AudioSource audioSource;
    public AudioClip lightSE;
    bool isPowerOneShot;
    float resetTimer; //回転盤を切り替えるたびにポンポンなるのを防ぐ

    // Start is called before the first frame update
    void Start()
    {
        childCount = transform.childCount; //子オブジェクトの数取得
        for (int i = 0; i < childCount; i++)
        {
            childObject[i] = transform.GetChild(i).gameObject;
        }

        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    childObject[i].GetComponentInChildren<Light>().enabled = false;
                }
                MatChange = false;
                hasLight = false;
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    childObject[i].GetComponentInChildren<Light>().enabled = true;
                }
                MatChange = true;
                hasLight = true;

                if (isPowerOneShot)
                {
                    audioSource.PlayOneShot(lightSE);
                    isPowerOneShot = false;
                }
            }

        }
        beforeColor = changeColor;
        meshRenderer.materials = MatChange ? materials2 : materials1;//
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn")  //点灯
        {
            //GetComponent<Renderer>().material.color = Color.yellow;
            changeColor = 1;
            resetTimer = 0;
        }
        else if (other.gameObject.tag == "EnergizedOff")    //消灯
        {
            //GetComponent<Renderer>().material.color = Color.white;
            changeColor = 0;
            resetTimer += Time.deltaTime;
            if (!isPowerOneShot && resetTimer >= 0.8f) isPowerOneShot = true;
        }
    }
}
