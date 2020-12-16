using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSStartProcess : MonoBehaviour
{
	[SerializeField] GameObject overviewWindow;
	// Start is called before the first frame update
	void Start()
    {
		overviewWindow.SetActive( true );
    }
}
