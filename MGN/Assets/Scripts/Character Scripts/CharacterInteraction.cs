using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour {

    public CharacterController2D character;
    private GameObject Cliente;
    private CharacterData characterData;

    private void Start()
    {
        characterData = transform.GetComponent<CharacterData>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = true;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Barra"))
        {
            ActivarMenuObjeto barra = collision.GetComponent<ActivarMenuObjeto>();
            barra.ActivarMenu();
        }

        if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Cliente"))
        {
            MovimientoCliente cliente = collision.GetComponent<MovimientoCliente>();
            if (cliente.disponible && !cliente.atendido)
            {
                cliente.atendido = true;
                cliente.GetComponentInChildren<ClientePidiendo>().aparece = false;
                cliente.GetComponentInChildren<ClienteAtendido>().aparece = true;
                Debug.Log("Cliente Atendido");
                
            }
            else if (cliente.disponible && cliente.atendido)
            {
                for (int i = 0; i < GameManager.cantidadBebidas; i++)
                {
                    if ((int)characterData.inventario[i].bebidaTipo == cliente.bebida)
                    {
                        characterData.removeBebida(characterData.inventario[i]);
                        cliente.servido = true;
                        cliente.GetComponentInChildren<ClienteAtendido>().aparece = false;
                        cliente.GetComponentInChildren<ClienteServido>().aparece = true;
                        break;
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = false;
    }
}
