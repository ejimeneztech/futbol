using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    //config params
    [SerializeField] Player player;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    


    // state
    Vector2 playerToBallVector;
    bool hasStarted = false;

    //cached componenet ref
    AudioSource myAudioSource;

  

    // Use this for initialization)
    void Start()
    {
        //calculate diff/distance in vectors
        playerToBallVector = transform.position -player.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.volume = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            KickOnMouseClick();
          




        }
        
    }


    private void KickOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            
        }
    }



    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = paddlePos + playerToBallVector;
    }


    //play sound when ball collides with other assets
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            myAudioSource.volume = 1;
            myAudioSource.Play();
            
        }
    }


}
