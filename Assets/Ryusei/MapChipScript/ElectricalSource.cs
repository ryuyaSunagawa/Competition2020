using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalSource : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleyOn", 0.02f);
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeleyOn()
    {
        tag = "EnergizedOn";
    }
}
