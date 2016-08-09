using UnityEngine;
using System.Collections;

public class BarrierInstantiator: MonoBehaviour {

    public GameObject barrier;
    GameObject prefabClone;

    void Start()
    {
        
    }

	void Update()
	{
		instantiateBarrier ();
	}

	void instantiateBarrier()
	{
		if (!GameLogic.hasBarrier) 
		{
			GameLogic.hasBarrier = true;
			// Generate a random number for Y coordinates of the barrier
			float randomBarrierY = UnityEngine.Random.Range(-2.0f, 2.0f);

			// Generate a random number for X coordinates of the barrier
			float randomBarrierX = UnityEngine.Random.Range(-2.39f, 2.39f);

			prefabClone = Instantiate(barrier, new Vector2(randomBarrierX, randomBarrierY), Quaternion.identity) as GameObject;
		}

	}
}
