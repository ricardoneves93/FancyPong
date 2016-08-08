using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour, Effects {

    public float speed = 500;
    public float targetForce = Mathf.Sqrt(20);
    Rigidbody2D rb;
    public bool playerTurn;
    private int ballLocation;


    void Awake ()
    {
        spawnBall(false);
    }

    public void spawnBall(bool playerTurn)
    {
        // Set player turn
        this.playerTurn = playerTurn;

        rb = gameObject.GetComponent<Rigidbody2D>();

        // Compute a random position in the line
        GameObject half = GameObject.FindGameObjectWithTag("Half");
        float halfPosY = half.transform.position.y;
        float randomBallPosX = UnityEngine.Random.Range(-2.8f, 2.8f);

        Vector2 finalPos = new Vector2(randomBallPosX, halfPosY);

        gameObject.transform.position = finalPos;

        int directionX = UnityEngine.Random.Range(0, 1);

        float forceX = UnityEngine.Random.Range(0.2f, targetForce);

        if (directionX == 1)
            forceX = -forceX;

        float forceY;

        if (playerTurn)
        {
            forceY = Mathf.Sqrt(targetForce * targetForce - forceX * forceX);
        }
        else
        {
           forceY = -Mathf.Sqrt(targetForce * targetForce - forceX * forceX);
        }

        rb.velocity = new Vector2(0, 0);
        rb.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
    }
	
	void Update ()
    {
        updateBallField();
        blinkBall(1, 1.0f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "left_wall" || coll.gameObject.tag == "right_wall")
        {
            // Play the wall sound
            coll.gameObject.GetComponent<AudioSource>().Play();
        }
        else if(coll.gameObject.tag == "player_1_paddle" || coll.gameObject.tag == "player_2_paddle")
        {
            // Play the paddle sound
            coll.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void updateBallField()
    {
        if (gameObject.GetComponent<Transform>().position.y < 0)
            ballLocation = 1;
        else ballLocation = 2;
    }

    // Interface Methods

    public void blinkBall(int mode, float blinkInterval)
    {
        if (mode == 0)
        {
            Color lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, blinkInterval));
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
        }
        else if(mode == 1)
        {
            if(ballLocation == 1)
            {
                // Check in which field is the ball
                Color lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, blinkInterval));
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }
            
        }
        else if(mode == 2)
        {
            if (ballLocation == 2)
            {
                // Check in which field is the ball
                Color lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, blinkInterval));
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }
        }
        
       
    }
}


interface Effects
{
    /// <summary>
    /// Mode: 0 => Ball blinks on both fields
    /// Mode: 1 => Ball blinks on player 1 field
    /// Mode: 2 => Ball blinks on player 2 field
    /// </summary>
    /// <param name="mode"></param>
    void blinkBall(int mode, float blinkInterval);
}
