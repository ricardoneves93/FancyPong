using UnityEngine;
using System.Collections;

public class BarrierInstantiator: MonoBehaviour {

    public GameObject barrier;
    GameObject prefabClone;

    void Start()
    {
        prefabClone = Instantiate(barrier, transform.position, Quaternion.identity) as GameObject;
    }
}
