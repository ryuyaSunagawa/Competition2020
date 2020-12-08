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

    // Start is called before the first frame update
    void Start()
    {
        childCount = transform.childCount; //子オブジェクトの数取得
        for (int i = 0; i < childCount; i++)
        {
            childObject[i] = transform.GetChild(i).gameObject;
        }
		normalMat = GetComponent<MeshRenderer>().materials[ 0 ];
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
            }

        }
        beforeColor = changeColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnergizedOn")  //点灯
        {
            //GetComponent<Renderer>().material.color = Color.yellow;
            changeColor = 1;
        }
        else if (other.gameObject.tag == "EnergizedOff")    //消灯
        {
            //GetComponent<Renderer>().material.color = Color.white;
            changeColor = 0;
        }
    }
}
