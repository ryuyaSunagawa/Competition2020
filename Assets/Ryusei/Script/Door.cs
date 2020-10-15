using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Vector3 FirstPosition;

    // Start is called before the first frame update
    void Start()
    {
        FirstPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        if(transform.position.y <= 10f )
        {
        transform.position += new Vector3(0, 0.1f, 0);

        }
    }

    public void CloseDoor()
    {
        if (FirstPosition.y <= transform.position.y)
        {
            transform.position += new Vector3(0, -0.1f, 0);

        }
    }
}
