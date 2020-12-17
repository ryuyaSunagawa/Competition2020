using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRenderMiniLight : MonoBehaviour
{
    int changeColor;
    int beforeColor;

    public bool hasLight;

    int childCount; //子オブジェクトの数
    [SerializeField]GameObject[] childObject;
	[SerializeField] ParticleSystem steam;
	Material normalMat;
	[SerializeField] Material emittionMat;

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
		steam.Stop( true );
		normalMat = GetComponent<MeshRenderer>().materials[ 0 ];

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
				GetComponent<MeshRenderer>().materials[ 0 ] = normalMat;
				if( steam != null )	steam.Stop( true );
                hasLight = false;
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    childObject[i].GetComponentInChildren<Light>().enabled = true;
				}
				GetComponent<MeshRenderer>().materials[ 0 ] = emittionMat;
				hasLight = true;
				if( steam != null )	steam.Play( true );

                if (isPowerOneShot)
                {
                    audioSource.PlayOneShot(lightSE);
                    isPowerOneShot = false;
                }
            }

        }
        beforeColor = changeColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn")  //点灯
        {
            changeColor = 1;
            resetTimer = 0;
        }
        else if (other.gameObject.tag == "EnergizedOff")    //消灯
        {
            changeColor = 0;
            resetTimer += Time.deltaTime;
            if (!isPowerOneShot && resetTimer >= 0.8f) isPowerOneShot = true;
        }
    }
}
