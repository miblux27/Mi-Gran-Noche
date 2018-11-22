﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCliente : MonoBehaviour {

	public float velocidad;

	private float auxVelocidad;
	public float pedirRate;
	public float idleRate;
	public float tiempoPedir;
	public float tiempoIdle;
	private int rebota = 1;
	private Animator animator;
	private bool mirandoDerecha = true;
	public bool antendido = true; //No se le ha cogido nota al cliente
	public bool servido; //No se le ha servido lo que pide al cliente
    public Bebidas bebida;
    public Transform spawner;

	public GameObject señal;

    private void Start()
    {
        //Elegir la bebida que pedirá el personaje
        bebida = Bebidas.chupito;
        auxVelocidad = velocidad;
        Debug.Log(auxVelocidad);
        animator = GetComponent<Animator>();
        if (!antendido) InvokeRepeating("pedir", pedirRate, pedirRate);
        InvokeRepeating("idle", idleRate, idleRate);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (antendido && servido)
        {
            CancelInvoke("pedir");
            CancelInvoke("idle");
            transform.position = Vector2.Lerp(transform.position, spawner.position,Time.deltaTime);
            if (Mathf.Abs(transform.position.x - spawner.position.x) < 0.1)
            {
                Destroy(gameObject);
            }
        }
        else { Mover(); }
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
		if(collision.GetComponent<Collider2D>().CompareTag("Punto")) //Cambia de direccion
		{
			flip();
			rebota = -rebota;
		}
	}

	private void Mover()
	{
		
		if (rebota > 0)
		{
			Debug.Log("voy palante");
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, 0);
		}
		else 
			if(rebota < 0)
			{
				Debug.Log("voy izquierda");
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, 0);
			}
		animator.SetFloat("speed", (this.GetComponent<Rigidbody2D>().velocity.x != 0) ? 1f : -1f); //Cambia de animacion
		
	}

	private void pedir()
	{
		animator.SetBool("pedir", true);
		velocidad = 0;
		señal.SetActive(true); //Activa la señal
		Debug.Log("He pasado a pedir");
		if (antendido) pararPedir();
	}

	private void pararPedir()
	{
		Debug.Log("paro de pedir");
		animator.SetBool("pedir", false);
		velocidad = auxVelocidad;
		señal.SetActive(false); //Desactiva la señal
	}

	private void idle()
	{
		velocidad = 0;
		Debug.Log("He pasado al idle");
		Invoke("pararIdle", tiempoIdle);
	}

    private void pararIdle()
    {
		velocidad = auxVelocidad;
	}
	private void flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

}
