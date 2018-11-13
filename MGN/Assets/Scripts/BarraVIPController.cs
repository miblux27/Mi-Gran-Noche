using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVIPController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            //Abrir menú de bebidas compuestas
            Debug.Log("Menú de Bebidas compuestas");
        }
            
    }
}