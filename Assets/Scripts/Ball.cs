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
    [SerializeField] float randomFactor = 0.2f;

    //cached reference
    bool gameOn = false;
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;


    //state
    Vector2 diffToPaddle;

    // Use this for initialization
    void Start()
    {
        diffToPaddle = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
            myRigidBody2D.velocity = new Vector2(xVelOnClick, yVelOnClick);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tweakVelocity();

        if (gameOn)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }

    }

    private void tweakVelocity()
    {
        float x = UnityEngine.Random.Range(0f, randomFactor);
        float y = UnityEngine.Random.Range(0f, randomFactor);
        Vector2 velocityTweak = new Vector2(x, y);

        myRigidBody2D.velocity += velocityTweak;
    }
}
