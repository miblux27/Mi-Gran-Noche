using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeñalesClientes : MonoBehaviour {
	public GameObject señal;
	public MovimientoCliente cliente;
	private Vector3 spawnPoint;
	private float spawnPointX = 0.61f;
	private float spawnPointY = 1.2f;
	public float spawnTime;

	// Use this for initialization
	
	void Update () 
	{
		spawnPoint = cliente.transform.position;
		spawnPoint.x = spawnPoint.x + spawnPointX; 
		spawnPoint.y = spawnPoint.y + spawnPointY;
		transform.position = Vector3.MoveTowards(transform.position, cliente.transform.position, .01f);
	}	
}
