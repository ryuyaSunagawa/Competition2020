using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSE : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clickSE;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("A")) audioSource.PlayOneShot(clickSE);
    }
}
