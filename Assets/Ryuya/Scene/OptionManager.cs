using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionManager : MonoBehaviour
{
	PauseUIManager parentManager;
	Button myButton;
    // Start is called before the first frame update
    void Start()
    {
		parentManager = this.GetComponentInParent<PauseUIManager>();
		//myButton = this.GetComponent<Button>();
		this.TryGetComponent<Button>( out myButton );
    }

    // Update is called once per frame
    void Update()
    {
		if( parentManager.pausing )
		{
			myButton.interactable = true;
		}
		else
		{
			myButton.interactable = false;
		}

		//Debug.Log( EventSystem.current.currentSelectedGameObject.name );
    }
}