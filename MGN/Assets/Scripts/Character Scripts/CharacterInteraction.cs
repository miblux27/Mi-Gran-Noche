using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour {

    public CharacterController2D character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = true;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Barra"))
        {
            Debug.Log("activado");
            ActivarMenuObjeto barra = collision.GetComponent<ActivarMenuObjeto>();
            barra.ActivarMenu();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = false;
    }
}
