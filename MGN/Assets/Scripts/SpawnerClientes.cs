using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerClientes : MonoBehaviour {
	public GameObject cliente;
	public GameObject señal;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;
	private Vector3 spawnPoint;
	private float spawnPointX = 0.61f;
	private float spawnPointY = 1.2f; 
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Spawn () {
		int spawnPointsIndex = Random.Range(0, spawnPoints.Length);
		Instantiate(cliente, spawnPoints[spawnPointsIndex].position, spawnPoints[spawnPointsIndex].rotation);
		//Instantiate(señal, spawnPoints[spawnPointsIndex].position, spawnPoints[spawnPointsIndex].rotation);
	}
}
