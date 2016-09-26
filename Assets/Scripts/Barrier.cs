using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {

	public bool isActive = true;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (isActive) 
		{
			// Play the barrier sound
			AudioSource audio =  GetComponent<AudioSource>();
			audio.Play ();

			// Give the player a new power-up
			// Choose random powerup
			int powerUpId = PowerUp.getRandomPowerUp();
			PowerUp powerUp;

			Debug.Log ("Power-up: " + powerUpId);
			powerUpId = 2;
			switch (powerUpId)
			{
			case 1:
				powerUp = new BlinkBall (other.GetComponent<Ball>(), 1.5f);
				break;
			case 2:
				powerUp = new ResizePaddle (GameObject.FindGameObjectWithTag ("player_1_paddle").GetComponent<Paddle>(), (Paddle) GameObject.FindGameObjectWithTag ("player_2_paddle").GetComponent<Paddle>(), Constants.POWER_UP_PADDLE_RESIZE);
				break;
			default:
				powerUp = new BlinkBall (other.GetComponent<Ball>(), 1.5f);
				break;
			}



			Vector2 velocity = other.GetComponent<Rigidbody2D>().velocity;
			if (velocity.y > 0) 
			{
				// Give the player the chosen power-up
				StartCoroutine(powerUp.apply(1));
			} 
			else if (velocity.y < 0) 
			{
				// Give the player the chosen power-up
				StartCoroutine(powerUp.apply(2));
			}


			// Hide barrier
			hide();
			GameLogic.hasBarrier = false;
			StartCoroutine (GameLogic.setBarrierDelay(gameObject, audio.clip.length));
		}

	}

	// The object is hidden by setting scale to zero! And then it is destroyed after CoRoutine ends
	void hide()
	{
		isActive = false;
		gameObject.transform.localScale = new Vector2 (0, 0);
	}
}
