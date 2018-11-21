using System.Collections;
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
	public bool antendido = false; //No se le ha cogido nota al cliente
	private bool servido; //No se le ha servido lo que pide al cliente

	public GameObject señal;


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

	//Aqui va la interacción cliente - jugador
	private void OnTriggerStay2D(Collider2D collision)
    {
		if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
			antendido = true;
			//Desaparece icono de interrogacion
			servido = false;
			//Aparece icono del pedido que quiere
		}

		if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
			//Desaparece icono del pedido ya servido
			servido = true;
			Debug.Log("estoy servido");
			//El cliente se va
		}
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
	// Use this for initialization
	void Start () {
		
		auxVelocidad = velocidad;
		Debug.Log(auxVelocidad);
		animator = GetComponent<Animator>();
		if(!antendido) InvokeRepeating("pedir", pedirRate, pedirRate);
		InvokeRepeating("idle", idleRate, idleRate);
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Mover();
	}
}
