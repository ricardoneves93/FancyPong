using UnityEngine;
using System.Collections;

public abstract class PowerUp {
	private static int numberPowerUps = 1;

	protected PowerUp()
	{
	}

	public abstract void apply(int player);

	public static int getRandomPowerUp()
	{
		int powerUpId = UnityEngine.Random.Range(0, numberPowerUps + 1);
		return powerUpId;
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

	public override void apply(int player)
	{

		Debug.Log ("PowerUp");
		if(player == 1)
		{
			if(ball.ballLocation == 1)
			{
				// Check in which field is the ball
				Color lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, blinkInterval));
				ball.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
			}
			else
			{
				ball.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
			}

		}
		else if(player == 2)
		{
			if (ball.ballLocation == 2)
			{
				// Check in which field is the ball
				Color lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, blinkInterval));
				ball.GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
			}
			else
			{
				ball.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
			}
		}
	}
}
	
