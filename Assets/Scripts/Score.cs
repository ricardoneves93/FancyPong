using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int score = 0;
    public bool isTurn;

    void Start ()
    {
	
	}
	
	void Update ()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ball")
        {
            if(gameObject.tag == "player_1_dead")
            {
                score++;
                GameObject.Find("ScorePlayer1").GetComponent<Text>().text = "" + score;
            }
            else if(gameObject.tag == "player_2_dead")
            {
                score++;
                GameObject.Find("ScorePlayer2").GetComponent<Text>().text = "" + score;
            }

            // Restart the level changing turns
            // New Ball instance
            StartCoroutine(waitForKeyDown(KeyCode.Space, other));
        }
    }

    IEnumerator waitForKeyDown(KeyCode keyCode, Collider2D other)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;

        other.GetComponent<Ball>().spawnBall(GameLogic.changePlayerTurn());
    }
}
