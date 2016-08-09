using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {


	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// Play the barrier sound
		AudioSource audio =  GetComponent<AudioSource>();
		audio.Play ();

		// Give the player a new power-up


		// Erase barrier
		Destroy(gameObject, audio.clip.length);

	}
}
