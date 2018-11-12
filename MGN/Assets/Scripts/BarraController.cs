using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraController : MonoBehaviour 
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            //Abrir menú de bebidas sencillas
            Debug.Log("Menú de Bebidas");
        }
            
    }
}