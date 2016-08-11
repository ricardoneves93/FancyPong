using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {


	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// Play the barrier sound
		AudioSource audio =  GetComponent<AudioSource>();
		audio.Play ();

		// Give the player a new power-up
		// Choose random powerup
		int powerUpId = PowerUp.getRandomPowerUp();
		PowerUp powerUp;


		switch (powerUpId)
		{
		case 1:
			powerUp = new BlinkBall (other.GetComponent<Ball>(), 1.0f);
			break;
		default:
			powerUp = new BlinkBall (other.GetComponent<Ball>(), 1.0f);
			break;
		}



		Vector2 velocity = other.GetComponent<Rigidbody2D>().velocity;
		if (velocity.y > 0) 
		{
			// Give the player the chosen power-up
			powerUp.apply(1);
		} 
		else if (velocity.y < 0) 
		{
			// Give the player the chosen power-up
			powerUp.apply(2);
		}


		// Erase barrier
		Destroy(gameObject, audio.clip.length);
		GameLogic.hasBarrier = false;

	}
}
