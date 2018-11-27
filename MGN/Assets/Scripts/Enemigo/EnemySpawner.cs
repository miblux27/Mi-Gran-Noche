using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform enemy;

    // Use this for initialization
    void Start()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }

}
