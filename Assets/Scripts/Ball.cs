using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float speed = 1000;
    public float targetForce = Mathf.Sqrt(20);
    Rigidbody2D rb;
    public bool playerTurn;


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
        float randomBallPosX = Random.Range(-2.8f, 2.8f);

        Vector2 finalPos = new Vector2(randomBallPosX, halfPosY);

        gameObject.transform.position = finalPos;

        int directionX = Random.Range(0, 1);

        float forceX = Random.Range(0.2f, targetForce);

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
}
