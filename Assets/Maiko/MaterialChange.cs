using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    MeshRenderer meshRenderer;
    bool MatChange = false;
    [SerializeField] Material[] materials1;
    [SerializeField] Material[] materials2;

	[SerializeField] MiniLight lightObj = null;
	[SerializeField] bool isPumpkinObject = false;

	int pumpkinChange = 0;
	int beforePumpkin = 0;

	[SerializeField] Transform[] panelTransform = new Transform[ 3 ];

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
		if ( isPumpkinObject )
		{
			ChangePanelActive( false );
		}
	}

    // Update is called once per frame
    void Update()
    {
		if ( isPumpkinObject )
		{
			pumpkinChange = lightObj.changeColor;

			if ( pumpkinChange != beforePumpkin )
			{
				if ( lightObj.changeColor == 1 )
				{
					MatChange = true;
					ChangePanelActive( true );
				}
				else if ( lightObj.changeColor == 0 )
				{
					MatChange = false;
					ChangePanelActive( false );
				}
			}

			beforePumpkin = pumpkinChange;
		}

        meshRenderer.materials = MatChange ? materials2 : materials1;
    }

	void ChangePanelActive( bool flag )
	{
		foreach ( Transform changeActive in panelTransform )
		{
			changeActive.gameObject.SetActive( flag );
		}
	}
}
