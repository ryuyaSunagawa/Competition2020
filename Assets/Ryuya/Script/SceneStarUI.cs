using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStarUI : MonoBehaviour
{
	[SerializeField] CanvasGroup myCanvasGroup;
	[SerializeField] Image[] starImg = new Image[ 3 ];
	[SerializeField] HalloweenStage halloweenStage;

    // Start is called before the first frame update
    void Start()
    {

    }

	// Update is called once per frame
	void Update()
	{
		if ( GameManager.Instance.displayStarFlg ) {
			for ( int i = 1; i <= 3; i++ )
			{
				if ( halloweenStage.star >= i )
				{
					starImg[ i - 1 ].enabled = true;
				}
				else
				{
					starImg[ i - 1 ].enabled = false;
				}
			}
		} else if( !GameManager.Instance.displayStarFlg )
		{
			for ( int i = 1; i <= 3; i++ )
			{
				starImg[ i - 1 ].enabled = false;
			}
		}
    }
}
