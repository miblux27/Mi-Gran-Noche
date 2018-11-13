using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispensadorController : MonoBehaviour
{
    // Use this for initialization
    private Animator animator;
    private bool encendido;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Player"))
        { 
            if(!encendido)
            {
                //Cambiar animación Encendido

                //Indicar que esa animación ya esta siendo ejecutada
                encendido = true;
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                //Abrir menú de bebidas
                Debug.Log("Menú de Refrescos");
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
            if(encendido)
            {
                //Cambiar animación Apagado
                
                //Indicar que esa animación ya esta siendo ejecutada
                encendido = false;
            }    
        }
    }
}