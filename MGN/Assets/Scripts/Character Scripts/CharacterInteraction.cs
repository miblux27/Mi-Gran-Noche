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

        else if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Cliente"))
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
                for (int i = 0; i < characterData.inventario.Count; i++)
                {
                    if (characterData.inventario[i] != null && (int)characterData.inventario[i].bebidaTipo == cliente.bebida)
                    {
                        Bebida.BebidaTipo tipo = characterData.inventario[i].bebidaTipo;
                        characterData.inventario[i] = null;
                        cliente.servido = true;
                        cliente.GetComponentInChildren<ClienteAtendido>().aparece = false;
                        cliente.GetComponentInChildren<ClienteServido>().aparece = true;
                        switch (cliente.bebida)
                        {
                            case (int)Bebida.BebidaTipo.cerveza:
                                {
                                    GameManager.CantidadDinero += 20;
                                    Debug.Log("Tengo " + GameManager.CantidadDinero + " €");
                                    break;
                                }
                            case (int)Bebida.BebidaTipo.chupito:
                                {
                                    GameManager.CantidadDinero += 50;
                                    Debug.Log("Tengo " + GameManager.CantidadDinero + " €");
                                    break;
                                }
                            case (int)Bebida.BebidaTipo.cocktail:
                                {
                                    GameManager.CantidadDinero += 30;
                                    Debug.Log("Tengo " + GameManager.CantidadDinero + " €");
                                    break;
                                }
                        }
                        Debug.Log("Le he dado la bebida");
                        break;
                    }
                }
                Debug.Log("No he encontrado la bebida " + cliente.bebida);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = false;
    }
}
