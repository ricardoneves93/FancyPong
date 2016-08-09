using UnityEngine;
using System.Collections;

public static class GameLogic {

    private static bool playerTurn;
	public static bool hasBarrier = false;

	public static bool changePlayerTurn()
    {
        playerTurn = !playerTurn;
        return playerTurn;
    }

}
