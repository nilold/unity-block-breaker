using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelOnClick = 2f;
    [SerializeField] float yVelOnClick = 15f;
    [SerializeField] AudioClip[] ballSounds;

    //state
    bool gameOn = false;
    AudioSource myAudioSource;


    //state
    Vector2 diffToPaddle;

    // Use this for initialization
    void Start()
    {
        diffToPaddle = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOn)
        {
            LockBallToPaddle();
            LaunchBall();
        }

    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + diffToPaddle;
    }


    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameOn = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelOnClick, yVelOnClick);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameOn)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
           
    }


}
