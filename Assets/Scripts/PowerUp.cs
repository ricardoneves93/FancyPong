using UnityEngine;
using System.Collections;

public abstract class PowerUp {
	protected float startTime;
	protected float actualTime;

	protected PowerUp()
	{
	}

	public abstract IEnumerator apply(int player);

	public static int getRandomPowerUp()
	{
		int powerUpId = UnityEngine.Random.Range(0, Constants.NUMBER_POWER_UPS + 1);
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

		while ( getElapsedTime() < Constants.POWER_UP_DURATION_SECS)
		{
			if(player == 1)
			{
				if(ball.ballLocation == 2)
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
				if (ball.ballLocation == 1)
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
			actualTime = Time.time;
			yield return null;
		}

		ball.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

	}
}


class ResizePaddle: PowerUp {

	protected Paddle paddleP1;
	protected Paddle paddleP2;
	protected float resizeValue;

	public ResizePaddle(Paddle paddleP1, Paddle paddleP2, float resizeValue)
	{
		this.paddleP1 = paddleP1;
		this.paddleP2 = paddleP2;
		this.resizeValue = resizeValue;
	}

	public override IEnumerator apply (int player)
	{
		startTime = Time.time;
		actualTime = startTime;

		if(player == 1)
			paddleP1.transform.localScale += new Vector3 (0, resizeValue, 0);
		else paddleP2.transform.localScale += new Vector3 (0, resizeValue, 0);

		while (getElapsedTime () < Constants.POWER_UP_DURATION_SECS) 
		{
			actualTime = Time.time;
			yield return null;
		}
			

		if(player == 1)
			paddleP1.transform.localScale -= new Vector3 (0, resizeValue, 0);
		else paddleP2.transform.localScale -= new Vector3 (0, resizeValue, 0);
	}
}
