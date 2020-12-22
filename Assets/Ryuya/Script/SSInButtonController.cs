using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSInButtonController : MonoBehaviour
{
	Button parentButton;
	Color disableColor;
	Color enableColor;
	[SerializeField] MaskableGraphic myGraphic;
    // Start is called before the first frame update
    void Start()
    {
		disableColor = new Color( myGraphic.color.r, myGraphic.color.g, myGraphic.color.b, 100f / 255f );
		enableColor = myGraphic.color;
		parentButton = gameObject.GetComponentInParent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if( parentButton.interactable )
		{
			myGraphic.color = enableColor;
		}
		else if( !parentButton.interactable )
		{
			myGraphic.color = disableColor;
		}
    }
}
