using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class eventsystem1 : MonoBehaviour
{
	public int ahan = 0;
	public void Selected( Text text )
	{
		text.text = ( ++ahan ).ToString();
	}
}
