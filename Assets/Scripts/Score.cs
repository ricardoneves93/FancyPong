using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int score = 0;
    public bool isTurn;

    void OnTriggerEnter2D(Collider2D other)
    {
		// Wait for keydown to spawn the ball
		StartCoroutine(GameLogic.waitForKeyDown(KeyCode.Space, other.GetComponent<Ball>()));

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
				
        }
    }
}
