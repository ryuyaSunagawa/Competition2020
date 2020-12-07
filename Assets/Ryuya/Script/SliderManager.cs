using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderManager : MonoBehaviour
{
	[SerializeField] Color selectingColor = new Color( 0, 0, 0, 1 );
	[SerializeField] Color deselectColor = new Color( 0, 0, 0, 1 );

	Slider mySlider;
	[SerializeField] Image backPanel;
    // Start is called before the first frame update
    void Start()
    {
		mySlider = GetComponent<Slider>();
		backPanel.color = deselectColor;
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void Selecting()
	{
		backPanel.color = selectingColor;
	}

	public void DeSelect()
	{
		backPanel.color = deselectColor;
	}
}
