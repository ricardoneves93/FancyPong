using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {

    public float speed = 500;
    public float targetForce = Mathf.Sqrt(20);
    Rigidbody2D rb;
    public bool playerTurn;
    public int ballLocation;
	/* A smaller force avoids a spawn that has too much horizontal force */
	private const float spawnBallXForce = 1.0f;
	/* Avoids the ball to travel in 100% vertical direction continually (applies some randomness)*/
	private const float randomForceMaximum = 0.5f;

	void Start()
	{
		this.gameObject.GetComponent<Renderer> ().enabled = false;
	}


    void Awake ()
    {
		StartCoroutine(GameLogic.waitForKeyDown(KeyCode.Space, this));
    }

    public void spawnBall(bool playerTurn)
    {
		this.gameObject.GetComponent<Renderer> ().enabled = true;
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

		float forceX = UnityEngine.Random.Range(spawnBallXForce, targetForce);

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
			this.applyRandomForce ();
        }
    }

    void updateBallField()
    {
        if (gameObject.GetComponent<Transform>().position.y < 0)
            ballLocation = 1;
        else ballLocation = 2;
    }

	public void applyRandomForce() 
	{
		Vector2 forces;

		forces.x = UnityEngine.Random.Range(0.0f, randomForceMaximum);
		forces.y = UnityEngine.Random.Range(0.0f, randomForceMaximum);

		rb.AddForce (forces, ForceMode2D.Impulse);
	}
}

