using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
	MeshRenderer myRenderer;
	[SerializeField] Material glowMaterial;

	private void Start()
	{
		myRenderer = GetComponent<MeshRenderer>();
	}

	// Update is called once per frame
	void Update()
    {
        if( GameManager.Instance.isClear )
		{
			myRenderer.material = glowMaterial;
		}
    }
}
