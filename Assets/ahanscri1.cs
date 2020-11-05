using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ahanscri1 : MonoBehaviour
{
	[SerializeField] Transform ahan;
	[SerializeField, Range( 0f, 50f )] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Vector3 cross = Vector3.Cross();
		//Debug.Log( Vector3.Cross( Vector3.forward, ahan.position - Vector3.zero ) );
    }

	private void FixedUpdate()
	{
		if( Input.GetKey( KeyCode.A ) )
		{
			ahan.position += transform.right * Time.deltaTime * speed;
		} else if( Input.GetKey( KeyCode.D ) )
		{
			ahan.position += -( transform.right ) * Time.deltaTime * speed;
		}
	}
}
