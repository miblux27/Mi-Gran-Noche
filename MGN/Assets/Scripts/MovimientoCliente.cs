using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCliente : MonoBehaviour {

	public float velocidad;
	public float tiempo;
	private float contador;
	private int rebota = 1;

	private void OnTriggerEnter2D(Collider2D collision){
		if(collision.GetComponent<Collider2D>().CompareTag("Punto"))
		{
			rebota = -rebota;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		contador += Time.deltaTime;

		if (contador >= tiempo && rebota > 0)
		{
			Debug.Log("voy palante");
			this.GetComponent<Rigidbody2D>().velocity = new Vector3(velocidad, 0 , 0);
		}
		else 
			if(contador >= tiempo && rebota < 0)
			{
				Debug.Log("voy izquierda");
				this.GetComponent<Rigidbody2D>().velocity = new Vector3(-velocidad, 0 , 0);
			}
	}
}
