using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalSource : MonoBehaviour
{
    AudioSource audioSource;
	float beforeVolume = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleyOn", 0.02f);
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
		beforeVolume = GameManager.Instance.soundVolume;
		audioSource.volume = GameManager.Instance.soundVolume * 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if( beforeVolume != GameManager.Instance.soundVolume )
		{
			beforeVolume = GameManager.Instance.soundVolume;
			audioSource.volume = GameManager.Instance.soundVolume * 0.4f;
		}
    }

    void DeleyOn()
    {
        tag = "EnergizedOn";
    }
}
