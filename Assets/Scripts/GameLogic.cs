using UnityEngine;
using System.Collections;

public static class GameLogic {

    private static bool playerTurn;
	public static bool hasBarrier = false;
	public static bool hasDelayFinished = false;

	public static bool changePlayerTurn()
    {
        playerTurn = !playerTurn;
        return playerTurn;
    }

	public static IEnumerator setBarrierDelay(GameObject gameobjectToDestroy, float delayToErase)
	{
		hasDelayFinished = false;
		yield return new WaitForSeconds(3);
		if(gameobjectToDestroy != null)
			MonoBehaviour.Destroy(gameobjectToDestroy, delayToErase);
		hasDelayFinished = true;

	}

}
