using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour {

    public CharacterController2D character;

    private GameObject Cliente;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = true;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Barra"))
        {
            //Debug.Log("activado");
            //ActivarMenuObjeto barra = collision.GetComponent<ActivarMenuObjeto>();
            //barra.ActivarMenu();
            if (CharacterData.bebidas.Count < 3)
            {
                Debug.Log("Coger Bebida");
                CharacterData.bebidas.Add(Bebidas.cocktail);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Cliente"))
        {
            MovimientoCliente cliente = collision.GetComponent<MovimientoCliente>();
            if (!cliente.atendido)
            {
                cliente.atendido = true;
                cliente.GetComponentInChildren<ClientePidiendo>().aparece = false; //Desaparece el icono de pedir
                cliente.GetComponentInChildren<ClienteAtendido>().aparece = true; //Aparece icono de la bebida
                Debug.Log("Cliente Atendido");
            }
            else if (!cliente.servido)
            {
                if (CharacterData.bebidas.Contains(cliente.bebida))
                {
                    cliente.servido = true;
                    cliente.GetComponentInChildren<ClienteAtendido>().aparece = false; //Desaparece icono de bebida
                    cliente.GetComponentInChildren<ClienteServido>().aparece = true; //Aparece icono de satisfecho
                    CharacterData.bebidas.Remove(cliente.bebida);
                    Debug.Log("Cliente Servido");
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = false;
    }
}
