using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChristmasStage : MonoBehaviour
{
    const int MINILIGHT = 1;    //このステージのミニライト数
    const int BRANCH = 4;       //このステージの回転盤の数
    const int BRANCHLIMIT = 5;  //このステージで星獲得のために回転盤を回してもいい回数
    const int STAR = 3;         //スターの最大数
    const int GRAYSTAR = 2;     //グレイスター最大数

    const int STAGE = 1;        //このステージの番号
    //音----------------------
    AudioSource audioSource;
    //public AudioClip bellSE;
    bool isBellOneShot;
    //ミニライト-------------------------------------------------------------------------------
    [SerializeField] GameObject[] miniLight;
    SnowMan[] miniLightScript = new SnowMan[MINILIGHT];

    int lightNum = 0;

    bool[] isLightnum = new bool[MINILIGHT];           //ライト点灯時にnumに加算する処理を1回に
    bool hasLightStar = true;   //ミニライトで星獲得をの処理を1回に

    //ゴールライト-------------------------------------------------------------------------------
    [SerializeField] GameObject goalLight;
    NoRenderGoalLight goalLightScript;

    bool hasGoalLightStar = true;

    //回転盤---------------------------------------------------------------------------------------
    [SerializeField] GameObject[] branch;
    Branch[] branchScript = new Branch[BRANCH];
    int branchTurn;    //回転盤を回した回数
    bool hasBranchStar = true;
    List<Branch> branchScr = new List<Branch>();

    [SerializeField] ClearCanvasController clearCanvas;

    public int star = 0;   //獲得星数

    [SerializeField] private CameraController refCamera;  // カメラを参照する用
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        for (int i = 0; i < MINILIGHT; i++)
        {
            //missionLight[i] = GameObject.FindGameObjectWithTag("MiniLight");
            miniLightScript[i] = miniLight[i].GetComponent<SnowMan>();
        }

        for (int i = 0; i < BRANCH; i++)
        {
            branchScript[i] = branch[i].GetComponent<Branch>();
        }

        goalLightScript = goalLight.GetComponent<NoRenderGoalLight>();
		GameManager.Instance.sceneInformation = LoadUserState.Instance.stageInfo[ 2 ];
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
            }
            else if (!miniLightScript[i].hasLight && isLightnum[i]) //消灯したらlightNumから-1し点灯フラグをfalse
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
			if ( !LoadUserState.Instance.gotStar2[ 2 ] )
			{
				GameManager.Instance.starInfo2[ 2 ] = true;
				Debug.Log( "GetLightStar" );
			}
		}
        else if (lightNum < MINILIGHT && !hasLightStar)   //ミニライト全点灯の星を失点
        {
            --star;
            hasLightStar = true;
			if ( !LoadUserState.Instance.gotStar2[ 2 ] )
			{
				GameManager.Instance.starInfo2[ 2 ] = false;
				Debug.Log( "LeaveLightStar" );
			}
		}

        //回転盤を何回回転させたか取得
        //branchTrun = branchScript[0].branchNum + branchScript[1].branchNum + branchScript[2].branchNum;
        int ahan = 0;
        foreach (Branch br in branchScript)
        {
            ahan += br.branchNum;
        }
        branchTurn = ahan;

        //回転盤のスターを失ったか失ってないか
        if (branchTurn <= BRANCHLIMIT && hasBranchStar)  //7手以下の間スターを所持
        {
            ++star;
            hasBranchStar = false;
			if ( !LoadUserState.Instance.gotStar3[ 2 ] )
			{
				//star3 = true;
				GameManager.Instance.starInfo3[ 2 ] = true;
			}
		}
        else if (branchTurn > BRANCHLIMIT && !hasBranchStar) //8手以上でスター失点
        {
            --star;
            hasBranchStar = true;
			if ( !LoadUserState.Instance.gotStar3[ 2 ] )
			{
				//star3 = false;
				GameManager.Instance.starInfo3[ 2 ] = false;
			}
		}

        //ゴールライトがついたかどうか
        if (goalLightScript.hasLight && hasGoalLightStar)
        {
            //クリスマスステージはクリアと火薬に着火が同時にできるのでゴール判定を遅らせる
            Invoke("DelayMethod", 0.2f);
            hasGoalLightStar = false; //1回だけ通す処理

            if (!isBellOneShot)//ベルの音
            {
                //audioSource.PlayOneShot(bellSE);
                audioSource.Play();
                isBellOneShot = true;
            }
        }
    }

    void DelayMethod()
    {
        //クリスマスステージはクリアと火薬に着火が同時にできるのでゴール判定を遅らせる
        if (!GameManager.Instance.isFail)
        {
            ++star;
            if(star >= 3)gameObject.tag = "AllStar";
            //ズームアウトして回転させる
            refCamera.goalZoomOut = true;
            //クリアアニメーション
            player.clear = true;



            //クリア評価処理(ClearCanvasControllerへ)
            clearCanvas.ClearRate(star);


			//ステージ情報保存
			GameManager.Instance.SaveClearInformation( 2, star );
            //LoadUserState.Instance.SetPlayerData(2);
            //LoadUserState.Instance.stageStarNum[STAGE - 1] = star;
            //LoadUserState.Instance.Save();
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 1f;
        GameManager.Instance.nowScene = SceneManager.GetActiveScene().name;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
        GameManager.Instance.isPause = false;
        GameManager.Instance.isClear = false;
        Time.timeScale = 1f;
    }
}
