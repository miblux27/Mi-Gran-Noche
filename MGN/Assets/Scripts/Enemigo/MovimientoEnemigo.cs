using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MovimientoNPCs
{

    public float velocidad = 0.0f;
    private float primeraVelocidad;

    private float minRangeX;
    private float maxRangeX;

    private Vector3 minRange;
    private Vector3 maxRange;

    private int planta;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        planta = Random.Range(0, 1);

        switch (planta) {
            case 0:
                minRangeX = GameManager.rangoMinP0;
                maxRangeX = GameManager.rangoMaxP0;
                break;
            case 1:
                minRangeX = GameManager.rangoMinP1;
                maxRangeX = GameManager.rangoMaxP1;
                break;
            default:
                break;
        }

        minRange.x = minRangeX;
        maxRange.x = maxRangeX;

        minRange.y = transform.position.y;
        minRange.z = transform.position.z;
        maxRange.y = transform.position.y;
        maxRange.z = transform.position.z;

        animator = GetComponent<Animator>();

        primeraVelocidad = velocidad;
        InvokeRepeating("accion", 10.0f, 15.0f);

        flip();
    }

    // Update is called once per frame
    void Update()
    {
        if (mirandoDerecha)
        {
            transform.position = Vector3.MoveTowards(transform.position, maxRange, velocidad * Time.deltaTime);
            if (transform.position.x >= maxRangeX)
            {
                flip();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, minRange, velocidad * Time.deltaTime);
            if (transform.position.x <= minRangeX)
            {
                flip();
            }
        }
    }

    private void accion()
    {
        animator.SetBool("accion", true);
        velocidad = 0.0f;
        Invoke("movimiento", 8.0f);
    }

    private void movimiento()
    {
        animator.SetBool("accion", false);
        velocidad = primeraVelocidad;
    }
}

