using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerClientes : MonoBehaviour {
	public GameObject cliente;
	public float spawnTime = 3f;
	public Transform[] spawnPoints; 
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
		int spawnPointsIndex = Random.Range(0, spawnPoints.Length);
		Instantiate(cliente, spawnPoints[spawnPointsIndex].position, spawnPoints[spawnPointsIndex].rotation);
	}
}
