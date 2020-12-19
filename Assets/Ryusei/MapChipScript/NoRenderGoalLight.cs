using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRenderGoalLight : MonoBehaviour
{

    int changeColor;
    int beforeColor;

    public bool hasLight;

    int childCount; //子オブジェクトの数
    [SerializeField] GameObject[] childObject;
	MeshRenderer myMesh;
	float duration = 0f;

    // Start is called before the first frame update
    void Start()
    {
        childCount = transform.childCount; //子オブジェクトの数取得
        for (int i = 0; i < childCount; i++)
        {
            childObject[i] = transform.GetChild(i).gameObject;
        }
		myMesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		//敗北判定(クリスマスオンリー)
		if ( GameManager.Instance.isFail && GameManager.Instance.nowScene == "Christmas" )
		{
			changeColor = 2;
		}

		if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    childObject[i].GetComponentInChildren<Light>().enabled = false;
                }
                hasLight = false;
            }
            else if( changeColor == 1 )
            {
                for (int i = 0; i < childCount; i++)
                {
                    childObject[i].GetComponentInChildren<Light>().enabled = true;
                }
                hasLight = true;
            }
			else if( changeColor == 2 )
			{
				duration += Time.deltaTime;
			}
		}
		if( changeColor != 2 || ( changeColor == 2 && duration >= 3.6f ) )
		{
			if ( changeColor == 2 )
			{
				myMesh.material.color = new Color( 0.356f, 0.043f, 0.035f, 1 );
			}
			beforeColor = changeColor;
		}
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
