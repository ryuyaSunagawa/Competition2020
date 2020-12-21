using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decorationLight : MonoBehaviour
{
    int changeColor;
    int beforeColor;

    MeshRenderer meshRenderer;//
    bool MatChange = false;//
    [SerializeField] Material[] materials1;//
    [SerializeField] Material[] materials2;//

    public bool hasLight;

    GameObject goalLight;
    GoalLight goalLightScript;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        goalLight = GameObject.FindGameObjectWithTag("GoalLight");
        goalLightScript = goalLight.GetComponent<GoalLight>();
    }

    // Update is called once per frame
    void Update()
    {
		if( GameManager.Instance.nowScene == "Halloween" )
		{
			if ( goalLightScript.hasLight && LoadUserState.Instance.stageStarNum[ 0 ] == 3 )  //点灯
			{
				changeColor = 1;
			}
			else if ( !goalLightScript.hasLight )    //消灯
			{
				changeColor = 0;
			}
		}
		else
		{
			if ( goalLightScript.hasLight )  //点灯
			{
				changeColor = 1;
			}
			else if ( !goalLightScript.hasLight )    //消灯
			{
				changeColor = 0;
			}
		}

        if (beforeColor != changeColor)
        {
            if (changeColor == 0)
            {
                MatChange = false;
                hasLight = false;
            }
            else
            {
                MatChange = true;
                hasLight = true;
            }

        }
        beforeColor = changeColor;
        meshRenderer.materials = MatChange ? materials2 : materials1;//
    }
}
