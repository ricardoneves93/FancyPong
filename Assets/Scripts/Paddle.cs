using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public float paddleSpeed = 1;
	public PowerUp powerUp;

	void Update ()
    {
        if(gameObject.tag == "player_1_paddle")
        {
            float xPos = gameObject.transform.position.x + Input.GetAxis("HorizontalPlayer1") * paddleSpeed;
            Vector3 playerPos = new Vector3(Mathf.Clamp(xPos, -2.5f, 2.5f), -4.5f, 0);
            gameObject.transform.position = playerPos;
        }
        else if(gameObject.tag == "player_2_paddle")
        {
            float xPos = gameObject.transform.position.x + Input.GetAxis("HorizontalPlayer2") * paddleSpeed;
            Vector3 playerPos = new Vector3(Mathf.Clamp(xPos, -2.5f, 2.5f), 4.5f, 0);
            gameObject.transform.position = playerPos;
        }
       
	}
}
