using UnityEngine;
using System.Collections;

public class Barrier: MonoBehaviour {

    public GameObject barrier;
    GameObject prefabClone;

    void Start()
    {
        Debug.Log("start");
        prefabClone = Instantiate(barrier, transform.position, Quaternion.identity) as GameObject;
    }
}
