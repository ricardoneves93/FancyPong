using UnityEngine;
using System.Collections;

public abstract class PowerUp {
	private static int numberPowerUps = 1;
	protected float powerUpDurationSecs = 10.0f;
	protected float startTime;
	protected float actualTime;

	protected PowerUp()
	{
	}

	public abstract IEnumerator apply(int player);

	public static int getRandomPowerUp()
	{
		int powerUpId = UnityEngine.Random.Range(0, numberPowerUps + 1);
		return powerUpId;
	}

	protected float getElapsedTime()
	{
		return (actualTime - startTime);
	}
}


class BlinkBall : PowerUp {

	float blinkInterval;
	Ball ball;

	public BlinkBall(Ball ball, float blinkInterval): base()
	{
		this.blinkInterval = blinkInterval;	
		this.ball = ball;
	}

	public override IEnumerator apply(int player)
	{
		startTime = Time.time;
		actualTime = startTime;

		while ( getElapsedTime() < powerUpDurationSecs) 
		{
			Debug.Log ("Elapsed Time: " + getElapsedTime ());
			if(player == 1)
			{
				if(ball.ballLocation == 2)
				{
					// Check in which field is the ball
					Color lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, blinkInterval));
					Debug.Log ("Blink player 1");
					ball.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
				}
				else
				{
					ball.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
				}

			}
			else if(player == 2)
			{
				if (ball.ballLocation == 1)
				{
					// Check in which field is the ball
					Color lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, blinkInterval));
					Debug.Log ("Blink player 2");
					ball.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
				}
				else
				{
					ball.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
				}
			}
			actualTime = Time.time;
			yield return null;
		}






	}
}
	
