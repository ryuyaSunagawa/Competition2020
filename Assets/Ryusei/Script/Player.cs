using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;        // 移動速度
    [SerializeField] private float applySpeed = 0.2f;     // 振り向きの適用速度
    [SerializeField] private CameraController refCamera;  // カメラの水平回転を参照する用
    Animator anim;

    public bool clear;
	float beforeVolume = 0f;

    public bool isElebator;

    //音-----------------------------------
    AudioSource audioSource;
    public AudioClip walkSE;
    public AudioClip failSE;
    public AudioClip clearSE;


    bool isOneShot;
    bool isSE;

    private void Start()
    {
	    anim = GetComponent<Animator>();

		audioSource = GetComponent<AudioSource>();
		audioSource.volume = GameManager.Instance.soundVolume;
		beforeVolume = GameManager.Instance.soundVolume;
    }

	private void Update()
	{
		if( beforeVolume != GameManager.Instance.soundVolume )
		{
			audioSource.volume = GameManager.Instance.soundVolume;
			beforeVolume = GameManager.Instance.soundVolume;
			Debug.Log( GameManager.Instance.soundVolume );
		}
	}

	void FixedUpdate()
    {
        if (refCamera.startZoom && ( !GameManager.Instance.isClear && !GameManager.Instance.isFail )) //最初のズーム処理が終わったら動かせるようになる
        {
            // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得る
            velocity = Vector3.zero;
            //if (Input.GetKey(KeyCode.W))
            //    velocity.z += 1;
            //if (Input.GetKey(KeyCode.A))
            //    velocity.x -= 1;
            //if (Input.GetKey(KeyCode.S))
            //    velocity.z -= 1;
            //if (Input.GetKey(KeyCode.D))
            //    velocity.x += 1;

            if (!isElebator)
            {
                velocity.x = Input.GetAxis("Horizontal");
                velocity.z = Input.GetAxis("Vertical");
            }else if (isElebator)
            {
                anim.SetBool("Idle", true);
                anim.SetBool("Walk", false);
            }

            // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整
            velocity = velocity.normalized * moveSpeed * Time.deltaTime;

            // いずれかの方向に移動している場合
            if (velocity.magnitude > 0)
            {
                if (isOneShot)
                {
                    audioSource.PlayOneShot(walkSE);
                    isOneShot = false;
                }
                anim.SetBool( "Idle", false );
				anim.SetBool( "Walk", true );
				// プレイヤーの回転(transform.rotation)の更新
				transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(refCamera.hRotation * velocity),
                                                      applySpeed);

                // プレイヤーの位置(transform.position)の更新
                transform.position += refCamera.hRotation * velocity;
            } else
			{
                if (!isOneShot && !clear && !GameManager.Instance.isFail)
                {
                    audioSource.Stop();
                    isOneShot = true;
                }
                anim.SetBool( "Idle", true );
				anim.SetBool( "Walk", false );
			}
        }
        if (clear)
        {
            if (!isSE)
            {
                audioSource.Stop();
                isOneShot = true;
                isSE = true;
            }
            if (isOneShot)
            {
                audioSource.PlayOneShot(clearSE);
                isOneShot = false;
            }
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Clear", true);
        }
        if (GameManager.Instance.isFail)
        {
            if (!isSE)
            {
                audioSource.Stop();
                isOneShot = true;
                isSE = true;
            }
            if (isOneShot)
            {
                audioSource.PlayOneShot(failSE);
                isOneShot = false;
            }
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Over", true);
        }
    }
}
