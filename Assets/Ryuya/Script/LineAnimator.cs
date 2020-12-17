using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineAnimator : MonoBehaviour
{
	Color clear = new Color( 1, 1, 1, 0 );
	Color opacity = new Color( 1, 1, 1, 1 );
	Image myImage;
	Animator myAnimator = null;

    AudioSource audioSource;
    public AudioClip celectSE;
    public AudioClip clickSE;
    bool isOneShot;

    private void Start()
	{
		myImage = GetComponent<Image>();
		myImage.color = clear;
		if ( gameObject.TryGetComponent<Animator>( out myAnimator ) )
		{
			myAnimator.speed = 0f;
		};

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (myImage.color == opacity && Input.GetButtonDown("A")) audioSource.PlayOneShot(clickSE);
    }

    public void  StartAnimation()
	{
        myImage.color = opacity;
		myAnimator.Play( "LineAnimationR", 0, 0 );
		myAnimator.speed = 1f;

        audioSource.PlayOneShot(celectSE);
    }

	public void StopAnimation()
	{
        myImage.color = clear;
		myAnimator.speed = 0;
    }
}
