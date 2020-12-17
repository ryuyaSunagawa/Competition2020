using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLight : MonoBehaviour
{
    public int changeColor;
    int beforeColor;

    MeshRenderer meshRenderer;//
    bool MatChange = false;//
    [SerializeField] Material[] materials1;//
    [SerializeField] Material[] materials2;//

    public bool hasLight;

    AudioSource audioSource;
    public AudioClip lightSE;
    bool isPowerOneShot;
    float resetTimer; //回転盤を切り替えるたびにポンポンなるのを防ぐ

    // Start is called before the first frame update
    void Start()
    {
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
                //GetComponent<Renderer>().material.color = Color.white;
                MatChange = false;
                hasLight = false;
            }
            else
            {
                //GetComponent<Renderer>().material.color = Color.yellow;
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
