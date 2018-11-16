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
        if (collision.GetComponent<Collider2D>().CompareTag("Player") && !encendido)
        { 
            encendido = true;    
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Collider2D>().CompareTag("Player") && encendido)
        {
            encendido = false;  
        }
    }
}