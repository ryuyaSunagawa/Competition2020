using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
	[SerializeField] Image myImage;
	[SerializeField] Text myText;

	float optionAlphaVar = 0f;
	float alphaUpLimit = 255f;
	float alphaLowLimit = 0f;

	[SerializeField] float alphaRange = 0f;

	[SerializeField] int whichOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        if( gameObject.tag == "UI_Image" )
		{
			whichOption = 1;
			Color color = myImage.color;
			color.a = alphaLowLimit;
			myImage.color = color;
		} else if( gameObject.tag == "UI_Text" )
		{
			whichOption = 2;
			Color color = myImage.color;
			color.a = alphaLowLimit;
			myText.color = color;
		}
    }

    // Update is called once per frame
    void Update()
    {
		//オプションに入る場合
        if( optionAlphaVar < alphaRange && GameManager.Instance.isPause )
		{
			optionAlphaVar += 5;

			if ( whichOption == 1 )
			{
				Color color = myImage.color;
				color.a = optionAlphaVar / alphaUpLimit;

				myImage.color = color;
			}
			else if ( whichOption == 2 )
			{
				Color color = myText.color;
				color.a = optionAlphaVar / alphaUpLimit;

				myText.color = color;
			}
		}
		//オプションから抜けるとき
		else if( optionAlphaVar > alphaLowLimit && !GameManager.Instance.isPause )
		{
			optionAlphaVar -= 5f;

			if ( whichOption == 1 )
			{
				Color color = myImage.color;
				color.a = optionAlphaVar / alphaUpLimit;

				myImage.color = color;
			}
			else if ( whichOption == 2 )
			{
				Color color = myText.color;
				color.a = optionAlphaVar / alphaUpLimit;

				myText.color = color;
			}
		}
    }
}
