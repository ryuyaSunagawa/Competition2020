using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalloweenStage : MonoBehaviour
{
    const int MINILIGHT = 4;    //このステージのミニライト数
    const int BRANCH = 3;       //このステージの回転盤の数
    const int BRANCHLIMIT = 7;  //このステージで星獲得のために回転盤を回してもいい回数
    const int STAR = 3;         //スターの最大数

    const int STAGE = 1;        //このステージの番号
    //ミニライト-------------------------------------------------------------------------------
    [SerializeField] GameObject[] miniLight;
    MiniLight[] miniLightScript = new MiniLight[MINILIGHT];
	[SerializeField] Light[] pumpkinLight;

    int lightNum = 0;

    bool[] isLightnum = new bool[MINILIGHT];           //ライト点灯時にnumに加算する処理を1回に
    bool hasLightStar = true;   //ミニライトで星獲得をの処理を1回に

    //ゴールライト-------------------------------------------------------------------------------
    [SerializeField]GameObject goalLight;
    GoalLight goalLightScript;

    bool hasGoalLightStar = true;

    //回転盤---------------------------------------------------------------------------------------
    [SerializeField] GameObject[] branch;
    Branch[] branchScript = new Branch[BRANCH];
    int branchTurn;    //回転盤を回した回数
    bool hasBranchStar = true;
    List<Branch> branchScr = new List<Branch>();

    [SerializeField] GameObject[] starImage;
    [SerializeField] GameObject clearText;

    int star = 0;   //獲得星数

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < MINILIGHT; i++)
        {
            //missionLight[i] = GameObject.FindGameObjectWithTag("MiniLight");
            miniLightScript[i] = miniLight[i].GetComponent<MiniLight>();
        }

        for(int i = 0; i < BRANCH; i++)
        {
            branchScript[i] = branch[i].GetComponent<Branch>();
        }

        for(int i = 0; i < STAR; i++)
        {
            starImage[i].SetActive(false);
        }
        clearText.SetActive(false);

		foreach( Light pumpkin in pumpkinLight )
		{
			pumpkin.enabled = false;
		}

        goalLightScript = goalLight.GetComponent<GoalLight>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("star"+star);
        //Debug.Log("lightnum"+lightNum);
        //Debug.Log("branchTrun" + branchTurn);

        //ミニライトがいくつ点灯しているか取得
        for (int i = 0; i < MINILIGHT; i++)
        {
            if (miniLightScript[i].hasLight && !isLightnum[i])  //点灯したらlightNumに+1し点灯フラグをtrue
            {
                ++lightNum;
                isLightnum[i] = true;
            }else if(!miniLightScript[i].hasLight && isLightnum[i]) //消灯したらlightNumから-1し点灯フラグをfalse
            {
                --lightNum;
                isLightnum[i] = false;
            }
        }

        //ミニライトのスターを獲得したか失ったか
        if (lightNum >= MINILIGHT && hasLightStar)    //ミニライト全点灯の星を獲得
        {
            ++star;
            hasLightStar = false;
        }
        else if(lightNum < MINILIGHT && !hasLightStar)   //ミニライト全点灯の星を失点
        {
            --star;
            hasLightStar = true;
        }

        //回転盤を何回回転させたか取得
        //branchTrun = branchScript[0].branchNum + branchScript[1].branchNum + branchScript[2].branchNum;
        int ahan = 0;
        foreach( Branch br in branchScript )
        {
            ahan += br.branchNum;
        }
        branchTurn = ahan;


        //for(int i = 0; i < BRANCH; i++)
        //{
        //    branchTrun = branchTrun + branchScript[i].branchNum;
        //}

        //回転盤のスターを失ったか失ってないか
        if (branchTurn <= BRANCHLIMIT && hasBranchStar)  //7手以下の間スターを所持
        {
            ++star;
            hasBranchStar = false;
        }else if(branchTurn > BRANCHLIMIT && !hasBranchStar) //8手以上でスター失点
        {
            --star;
            hasBranchStar = true;
        }

        //ゴールライトがついたかどうか
        if (goalLightScript.hasLight && hasGoalLightStar)
        {
            ++star;
            hasGoalLightStar = false;
            LoadUserState.Instance.SetPlayerData(STAGE);

            Invoke("DelayHyouka", 0.1f);
        }
    }

    void DelayHyouka()
    {
        for (int i = 0; i < star; i++)  //starの数にあわせて星の画像表示
        {
            starImage[i].SetActive(true);
        }
        clearText.SetActive(true);

		foreach ( Light pumpkin in pumpkinLight )
		{
			pumpkin.enabled = true;
		}
	}

    //public void SetProgress(int value)
    //{
    //    if (progressedStageNum < value)
    //    {
    //        progressedStageNum = value;
    //    }
    //}
}
