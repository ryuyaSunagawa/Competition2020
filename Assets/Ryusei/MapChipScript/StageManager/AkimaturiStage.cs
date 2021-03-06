﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AkimaturiStage : MonoBehaviour
{
    const int MINILIGHT = 2;    //このステージのミニライト数
    const int GOALLIGHT = 2;    //このステージのゴールライトの数
    const int BRANCH = 5;       //このステージの回転盤の数
    const int BRANCHLIMIT = 7;  //このステージで星獲得のために回転盤を回してもいい回数
    const int STAR = 3;         //スターの最大数
    const int GRAYSTAR = 2;     //グレイスター最大数

    const int STAGE = 2;        //このステージの番号
    //ミニライト-------------------------------------------------------------------------------
    [SerializeField] GameObject[] miniLight;
    NoRenderMiniLight[] miniLightScript = new NoRenderMiniLight[MINILIGHT];

    int miniLightNum = 0;

    bool[] isMiniLightnum = new bool[MINILIGHT];           //ライト点灯時にnumに加算する処理を1回に
    bool hasLightStar = true;   //ミニライトで星獲得をの処理を1回に

    //ゴールライト-------------------------------------------------------------------------------
    [SerializeField] GameObject[] goalLight;
    NoRenderGoalLight[] goalLightScript = new NoRenderGoalLight[GOALLIGHT];

    int goalLightNum = 0;

    bool[] isGoalLightnum = new bool[GOALLIGHT];           //ライト点灯時にnumに加算する処理を1回に
    bool hasGoalLightStar = true;

    //回転盤---------------------------------------------------------------------------------------
    [SerializeField] GameObject[] branch;
    Branch[] branchScript = new Branch[BRANCH];
    int branchTurn;    //回転盤を回した回数
    bool hasBranchStar = true;
    List<Branch> branchScr = new List<Branch>();

    //[SerializeField] GameObject[] starImage;
    //[SerializeField] GameObject[] grayStar;
    //[SerializeField] GameObject clearText;
	[SerializeField] ClearCanvasController clearCanvas;
	[SerializeField] Light dirLight = null;
	[SerializeField, Header( "クリア後のライトの強さ" ), Range( 0f, 1f )] float clearLightIntencity = 1f;
	[SerializeField, Header( "クリア後のスカイボックス" )] Material clearSkybox;

    public int star = 0;   //獲得星数

    [SerializeField] private CameraController refCamera;  // カメラを参照する用
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < MINILIGHT; i++)
        {
            //missionLight[i] = GameObject.FindGameObjectWithTag("MiniLight");
            miniLightScript[i] = miniLight[i].GetComponent<NoRenderMiniLight>();
        }

        for (int i = 0; i < BRANCH; i++)
        {
            branchScript[i] = branch[i].GetComponent<Branch>();
        }

        //for (int i = 0; i < STAR; i++)
        //{
        //    starImage[i].SetActive(false);
        //}

        //for (int i = 0; i < GRAYSTAR; i++)
        //{
        //    grayStar[i].SetActive(false);
        //}

        //clearText.SetActive(false);

        for(int i = 0; i < GOALLIGHT; i++)
        {
            goalLightScript[i] = goalLight[i].GetComponent<NoRenderGoalLight>();
        }

		GameManager.Instance.sceneInformation = LoadUserState.Instance.stageInfo[ 1 ];
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
            if (miniLightScript[i].hasLight && !isMiniLightnum[i])  //点灯したらlightNumに+1し点灯フラグをtrue
            {
                ++miniLightNum;
                isMiniLightnum[i] = true;
            }
            else if (!miniLightScript[i].hasLight && isMiniLightnum[i]) //消灯したらlightNumから-1し点灯フラグをfalse
            {
                --miniLightNum;
                isMiniLightnum[i] = false;
            }
        }

        //ミニライトのスターを獲得したか失ったか
        if (miniLightNum >= MINILIGHT && hasLightStar)    //ミニライト全点灯の星を獲得
        {
            ++star;
            hasLightStar = false;
			if ( !LoadUserState.Instance.gotStar2[ STAGE - 1 ] )
			{
				GameManager.Instance.starInfo2[ STAGE - 1 ] = true;
			}
		}
        else if (miniLightNum < MINILIGHT && !hasLightStar)   //ミニライト全点灯の星を失点
        {
            --star;
            hasLightStar = true;
			if ( !LoadUserState.Instance.gotStar2[ STAGE - 1 ] )
			{
				GameManager.Instance.starInfo2[ STAGE - 1 ] = false;
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
			if ( !LoadUserState.Instance.gotStar3[ STAGE - 1 ] )
			{
				//star3 = true;
				GameManager.Instance.starInfo3[ STAGE - 1 ] = true;
			}
		}
        else if (branchTurn > BRANCHLIMIT && !hasBranchStar) //8手以上でスター失点
        {
            --star;
            hasBranchStar = true;
			if ( !LoadUserState.Instance.gotStar3[ STAGE - 1 ] )
			{
				//star3 = false;
				GameManager.Instance.starInfo3[ STAGE - 1 ] = false;
			}
		}

        //ミニライトがいくつ点灯しているか取得
        for (int i = 0; i < GOALLIGHT; i++)
        {
            if (goalLightScript[i].hasLight && !isGoalLightnum[i])  //点灯したらlightNumに+1し点灯フラグをtrue
            {
                ++goalLightNum;
                isGoalLightnum[i] = true;
            }
            else if (!miniLightScript[i].hasLight && isGoalLightnum[i]) //消灯したらlightNumから-1し点灯フラグをfalse
            {
                --goalLightNum;
                isGoalLightnum[i] = false;
            }
        }

        //全てのゴールライトがついたかどうか
        if (goalLightNum >= GOALLIGHT - 1 && hasGoalLightStar)
        {
            ++star;
            if (star >= 3) gameObject.tag = "AllStar";
            hasGoalLightStar = false;

            //ズームアウトして回転させる
            refCamera.goalZoomOut = true;
            //クリアアニメーション
            player.clear = true;

            //クリア評価
            clearCanvas.ClearRate( star );
			//クリア後のスカイボックス変更
			RenderSettings.skybox = clearSkybox;
			//沈むように溶けていくような夜に駆けてる感じにする
			dirLight.intensity = clearLightIntencity;

			//Invoke("DelayHyouka", 0.1f);
			GameManager.Instance.SaveClearInformation( 1, star );
			//LoadUserState.Instance.SetPlayerData(2);
   //         LoadUserState.Instance.stageStarNum[STAGE - 1] = star;
   //         LoadUserState.Instance.Save();
        }
    }

  //  void DelayHyouka()
  //  {
  //      for (int i = 0; i < star; i++)  //starの数にあわせて星の画像表示
  //      {
  //          starImage[i].SetActive(true);
  //      }
  //      for (int i = 0; i < (GRAYSTAR + 1) - star; i++) //星がないところにグレー星表示
  //      {
  //          grayStar[i].SetActive(true);
  //      }
  //      clearText.SetActive(true);
		//clearCanvas.clearFlg = true;
		//Cursor.lockState = CursorLockMode.None;
  //  }

    private void OnEnable()
    {
		GameManager.Instance.nowScene = SceneManager.GetActiveScene().name;
		//Debug.Log( SceneManager.GetActiveScene().name );
    }

    private void OnDestroy()
    {
        GameManager.Instance.isPause = false;
        Time.timeScale = 1f;
    }
}
