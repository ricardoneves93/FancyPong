using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour {

	private Resolution screenResolution;
	private Vector2 touchPosition;
	private int halfHeight;
	private int halfWidth;
	private Ball ball;

	void Start()
	{
		// Get the current device screen resolution
		screenResolution = Screen.currentResolution;

		halfHeight = screenResolution.height / 2;
		halfWidth = screenResolution.height / 2;

		ball = GameObject.FindGameObjectWithTag ("Ball").GetComponent<Ball> ();

	}

	void Update () 
	{
		if (GameLogic.isGamePaused) 
		{
			if (Input.touchCount > 0) 
			{
				Vector2 touchPosition = Input.GetTouch (0).position;

				// Player 1 turn
				if (GameLogic.playerTurn) 
				{
					if (touchPosition.y < halfHeight) 
					{
						ball.spawnBall (GameLogic.changePlayerTurn ());
						GameLogic.isGamePaused = false;
					}
				}
				// Player 2 turn
				else if (!GameLogic.playerTurn) 
				{
					if (touchPosition.y >= halfHeight) 
					{
						ball.spawnBall (GameLogic.changePlayerTurn ());
						GameLogic.isGamePaused = false;
					}

				}
				
			}


		} else if (!GameLogic.isGamePaused) 
		{
			if (Input.touchCount > 0) 
			{
				Vector2 touchPosition = Input.GetTouch (0).position;

				if (touchPosition.y < halfHeight) 
				{
					if (touchPosition.x < halfWidth) 
					{
						
					}

					if (touchPosition.x >= halfWidth) 
					{

					}

				}

				if (touchPosition.y >= halfHeight) 
				{
					if (touchPosition.x < halfWidth) 
					{

					}

					if (touchPosition.x >= halfWidth) 
					{

					}
				}
			}
		}
	}
}
