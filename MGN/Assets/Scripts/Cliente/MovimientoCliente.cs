using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCliente : MonoBehaviour{

	public float velocidad;

    private Vector3 target;
    private Vector3 originalPosition;
    private Vector3 posicionBaile;

    int zonasPosibles;
    int rndm;
    int rndmBailar;

    private float auxVelocidad;
	public float pedirRate;
	public float idleRate;
	public float tiempoPedir;
	public float tiempoIdle;
	private int rebota = 1;
	private Animator animator;
    private Rigidbody2D rgbd;
	private bool mirandoDerecha = true;
	public bool atendido = false; //No se le ha cogido nota al cliente
	public bool servido; //No se le ha servido lo que pide al cliente
    public Bebidas bebida;

	public GameObject señal;

    private void Start()
    {
        //Elegir la bebida que pedirá el personaje
        bebida =(Bebidas)Random.Range(1, GameManager.cantidadBebidas);
        Debug.Log("Voy a pedir " + bebida);
        auxVelocidad = velocidad;
        animator = GetComponent<Animator>();
        //rgbd = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;

        rndmBailar = Random.Range(0, GameManager.zonasDeBaile.Length);
        while (GameManager.zonasDeBaileOcupadas[rndmBailar]) rndmBailar = Random.Range(0, GameManager.zonasDeBaile.Length);
        GameManager.zonasDeBaileOcupadas[rndmBailar] = true;
        posicionBaile.x = GameManager.zonasDeBaile[rndmBailar];
        posicionBaile.y = transform.position.y;
        posicionBaile.z = transform.position.z;

        rndm = Random.Range(0, GameManager.zonasDisponibles.Length);
        while (GameManager.zonasOcupadas[rndm]) rndm = Random.Range(0, GameManager.zonasDisponibles.Length);
        GameManager.zonasOcupadas[rndm] = true;
        target.x = GameManager.zonasDisponibles[rndm];
        target.y = transform.position.y;
        target.z = transform.position.z;
        //if (!atendido) InvokeRepeating("pedir", pedirRate, pedirRate);
        //InvokeRepeating("idle", idleRate, idleRate);
        Debug.Log("voy a posicionarme");
        //Invoke("irPosicion", 0.5f);
        StartCoroutine("bailar");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target, auxVelocidad * Time.deltaTime);
        //Mover();
    }

    public IEnumerator bailar()
    {
        if (transform.position.x > posicionBaile.x) flip();
        while (transform.position != posicionBaile)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionBaile, auxVelocidad * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        for (int i = 0; i < GameManager.zonasDeBaile.Length; i++)
        {
            yield return new WaitForSeconds(2.0f);
            flip();
        }
        GameManager.zonasDeBaileOcupadas[rndmBailar] = false;
        StartCoroutine("irPosicion");
        StopCoroutine("bailar");
    }

    public IEnumerator irPosicion() {
        if (transform.position.x > target.x && mirandoDerecha) flip();
        else if (transform.position.x < target.x && !mirandoDerecha) flip();
        while (transform.position != target) {
            transform.position = Vector3.MoveTowards(transform.position, target, auxVelocidad * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        // Aquí el cliente tiene que realizar el pedido
        StartCoroutine("timerCliente");
        StopCoroutine("irPosicion");
    }

    public IEnumerator timerCliente()
    {
        int tiempo = 15;
        while (tiempo > 0) {
            /*if (atendido) {
                StartCoroutine("denegarComanda");
                StopCoroutine("timerCliente");
            }*/
            tiempo -= 1;
            yield return new WaitForSeconds(1.0f);
        }

        GameManager.zonasOcupadas[rndm] = false;
        StartCoroutine("abandonarLocal");
        StopCoroutine("timerClientes");
    }

    public IEnumerator denegarComanda()
    {
        int tiempo = 15;
        while (tiempo > 0)
        {
            /*if (atendido)
            {
                StartCoroutine("abandonarLocal");
                StopCoroutine("denegarComanda");
            }*/
            tiempo -= 1;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        GameManager.zonasOcupadas[rndm] = false;
        StartCoroutine("abandonarLocal");
        StopCoroutine("denegarComanda");
    }

    private IEnumerator abandonarLocal() {
        if (transform.position.x > originalPosition.x && mirandoDerecha) flip();
        else if (transform.position.x < originalPosition.x && !mirandoDerecha) flip();
        while (transform.position != originalPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, auxVelocidad * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Destroy(this.gameObject);
        StopCoroutine("abandonarLocal");
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
		if (atendido) pararPedir();
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
