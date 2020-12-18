using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeController : MonoBehaviour
{
	[SerializeField] bool oneShot = false;
	bool oneShotFlg = false;
	int shotNum = 0;
	[SerializeField] float duration = 0f;
	[SerializeField] FailBom parentFailBomb;
	float nowDuration = 0f;
	ParticleSystem myParticle;
	[SerializeField] string str = "";
    // Start is called before the first frame update
    void Start()
    {
		myParticle = this.GetComponent<ParticleSystem>();
		Debug.Log( myParticle.isPlaying );
		myParticle.Clear();
		myParticle.Stop();
	}

    // Update is called once per frame
    void Update()
    {
		if( parentFailBomb.failFlg )
		{
			nowDuration += Time.deltaTime;
			if( nowDuration >= duration && !oneShotFlg )
			{
				myParticle.Play();
				if ( oneShot && !oneShotFlg )
				{
					oneShotFlg = true;
				}
			}
		}
    }
}
