using UnityEngine;
using System.Collections;

public static class GameLogic {

    private static bool playerTurn;
	public static bool hasBarrier = false;
	public static bool hasDelayFinished = false;
	public static bool isGamePaused = true;

	public static bool changePlayerTurn()
    {
        playerTurn = !playerTurn;
        return playerTurn;
    }

	public static IEnumerator setBarrierDelay(GameObject gameobjectToDestroy, float delayToErase)
	{
		hasDelayFinished = false;
		yield return new WaitForSeconds((int) Constants.POWER_UP_DURATION_SECS);
		if(gameobjectToDestroy != null)
			MonoBehaviour.Destroy(gameobjectToDestroy, delayToErase);
		hasDelayFinished = true;

	}

	public static IEnumerator waitForKeyDown(KeyCode keyCode, Ball ball)
	{
		while (!Input.GetKeyDown (keyCode)) 
		{
			GameLogic.isGamePaused = true;
			yield return null;
		}
		GameLogic.isGamePaused = false;

		ball.spawnBall(GameLogic.changePlayerTurn());
	}

}
