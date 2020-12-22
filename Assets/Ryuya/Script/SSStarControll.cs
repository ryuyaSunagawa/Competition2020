using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSStarControll : MonoBehaviour
{
	[SerializeField] int starNumber = 0;

	[SerializeField, Header( "グレーの星" )] Sprite greySprite;
	[SerializeField, Header( "光る星" )] Sprite glowSprite;

    [SerializeField] SSOverviewManager myParent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
	{
		if ( starNumber == 0 && LoadUserState.Instance.gotStar1[ myParent.ss.stageNumber - 1 ] )
		{
			GetComponent<Image>().sprite = glowSprite;
		}
		else if ( starNumber == 1 && !LoadUserState.Instance.gotStar1[ myParent.ss.stageNumber - 1 ] )
		{
			GetComponent<Image>().sprite = greySprite;
		}

		if ( starNumber == 1 && LoadUserState.Instance.gotStar2[ myParent.ss.stageNumber - 1 ] )
		{
			GetComponent<Image>().sprite = glowSprite;
		}
		else if ( starNumber == 1 && !LoadUserState.Instance.gotStar2[ myParent.ss.stageNumber - 1 ] )
		{
			GetComponent<Image>().sprite = greySprite;
		}

		if ( starNumber == 2 && LoadUserState.Instance.gotStar3[ myParent.ss.stageNumber - 1 ] )
		{
			GetComponent<Image>().sprite = glowSprite;
		}
		else if ( starNumber == 2 && !LoadUserState.Instance.gotStar3[ myParent.ss.stageNumber - 1 ] )
		{
			GetComponent<Image>().sprite = greySprite;
		}
	}
}
