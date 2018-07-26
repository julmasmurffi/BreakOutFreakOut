using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //conf params
    [SerializeField] Paddle paddle1;
    [SerializeField] float speedX = 2f;
    [SerializeField] float speedY = 20f;
    [SerializeField] AudioClip[] ballSounds;

    //state
    Vector2 paddleToBallV;
    bool hasStarted = false;

    //cached component references
    AudioSource myAudioSource;

    // Use this for initialization
	void Start ()
    {
        //refers to ball because of set in unity editor
        paddleToBallV = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallV;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, speedY);
            hasStarted = true;
        }
    }

    //trigger sounds
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }

}
