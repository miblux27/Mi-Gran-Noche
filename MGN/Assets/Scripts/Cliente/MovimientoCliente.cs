﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCliente : MonoBehaviour{

    // Velocidad del personaje
	public float velocidad;

    // Posición de pedir y de baile
    int zonasPosibles;
    int rndm;
    int rndmBailar;

    private Vector3 target;
    private Vector3 originalPosition;
    private Vector3 posicionBaile;

    // Comportamiento
    private Animator animator;
    private Rigidbody2D rgbd;
    private bool mirandoDerecha = true;
    public bool atendido = false; //No se le ha cogido nota al cliente
    public bool servido = false; //No se le ha servido lo que pide al cliente
    public Bebidas bebida;

    // Parámetros auxiliares
    private float auxVelocidad;
	private int rebota = 1;
    private bool deboDestruirme;
    private bool deboDestruirme2;
	

    private void Awake()
    {
        deboDestruirme = true;
        for (int i = 0; i < GameManager.zonasDeBaileOcupadas.Length; i++)
        {
            if (!GameManager.zonasDeBaileOcupadas[i])
            {
                deboDestruirme = false;
                break;
            }
        }

        deboDestruirme2 = true;
        for (int i = 0; i < GameManager.zonasOcupadas.Length; i++)
        {
            if (!GameManager.zonasOcupadas[i])
            {
                deboDestruirme2 = false;
                break;
            }
        }

        GetComponentInChildren<ClientePidiendo>().GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);
        GetComponentInChildren<ClienteServido>().GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);
        GetComponentInChildren<ClienteAtendido>().GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);
        GetComponentInChildren<ClienteFail>().GetComponentInChildren<SpriteRenderer>().gameObject.SetActive(false);

        if (deboDestruirme || deboDestruirme2) Destroy(this.gameObject);
    }

    private void Start()
    {

        // Inicializar comportamiento
        bebida = (Bebidas)Random.Range(1, GameManager.cantidadBebidas);
        auxVelocidad = velocidad;
        animator = GetComponent<Animator>();

        // Asignar posiciones de pedir y baile
        originalPosition = transform.position;

        rndmBailar = Random.Range(0, GameManager.zonasDeBaile.Length);
        while (GameManager.zonasDeBaileOcupadas[rndmBailar]) rndmBailar = Random.Range(0, GameManager.zonasDeBaile.Length);
        GameManager.zonasDeBaileOcupadas[rndmBailar] = true;
        posicionBaile.x = GameManager.zonasDeBaile[rndmBailar];
        posicionBaile.y = transform.position.y;
        posicionBaile.z = transform.position.z;

        rndm = Random.Range(0, GameManager.zonasOcupadas.Length);
        while (GameManager.zonasOcupadas[rndm]) rndm = Random.Range(0, GameManager.zonasOcupadas.Length);
        GameManager.zonasOcupadas[rndm] = true;
        target.x = GameManager.zonasDisponibles[rndm];
        target.y = transform.position.y;
        target.z = transform.position.z;

        // El personaje va a la posición de baile
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
        Debug.Log("estoy pidiendo");
        GetComponentInChildren<ClientePidiendo>().aparece = true; // Aquí el cliente tiene que realizar el pedido
        StartCoroutine("timerCliente");
        StopCoroutine("irPosicion");
    }

    public IEnumerator timerCliente()
    {
        
        int tiempo = 15;
        while (tiempo > 0) {
            if (atendido) 
            {
                Debug.Log("paso a decir lo que quiero");
                GetComponentInChildren<ClientePidiendo>().aparece = false;
                GetComponentInChildren<ClienteAtendido>().aparece = true;
                StartCoroutine("denegarComanda");
                StopCoroutine("timerCliente");
            }
            tiempo -= 1;
            yield return new WaitForSeconds(1.0f);
            Debug.Log("timer 1: " + tiempo);
        }

        GameManager.zonasOcupadas[rndm] = false;
        GetComponentInChildren<ClientePidiendo>().aparece = false;
        GetComponentInChildren<ClienteFail>().aparece = true;
        StartCoroutine("abandonarLocal");
        StopCoroutine("timerClientes");
    }

    public IEnumerator denegarComanda()
    {
        
        int tiempo = 15;
        while (tiempo > 0)
        {
            if (servido)
            {
                GetComponentInChildren<ClienteAtendido>().aparece = false;
                GetComponentInChildren<ClienteServido>().aparece = true;
                StartCoroutine("abandonarLocal");
                StopCoroutine("denegarComanda");
            }
           /*  else if (tiempo == 10) 
            {
                Debug.Log("me quedan 10 segundos");
                GetComponentInChildren<ClienteAtendido>().aparece = false;
                GetComponentInChildren<ClienteAtendido2>().aparece = true;
            }
            else if (tiempo == 5)
            {
                Debug.Log("me quedan 5 segundos");
                GetComponentInChildren<ClienteAtendido2>().aparece = false;
                GetComponentInChildren<ClienteAtendido3>().aparece = true;
            }*/
            tiempo -= 1;
            yield return new WaitForSeconds(1.0f);
            Debug.Log("timer 2: " + tiempo);
        }

        GetComponentInChildren<ClienteAtendido>().aparece = false;
        GetComponentInChildren<ClienteFail>().aparece = true;
        GameManager.zonasOcupadas[rndm] = false;
        StartCoroutine("abandonarLocal");
        StopCoroutine("denegarComanda");
    }

    private IEnumerator abandonarLocal() {
        if(!servido)
        {
            Debug.Log("me piro sin ser servido");
            //GetComponentInChildren<ClientePidiendo>().aparece = false;
            //GetComponentInChildren<ClienteAtendido>().aparece = false;
            //GetComponentInChildren<ClienteFail>().aparece = true;
        }
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

	private void flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

}
