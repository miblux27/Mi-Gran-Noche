using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour {

    public CharacterController2D character;
    public bool golpeado = false;

    private GameObject Cliente;
    private CharacterData characterData;

    private SpriteRenderer spriteRenderer;
    private int contador = 0;
    private bool limiteColor = false;

    private void Start()
    {
        characterData = transform.GetComponent<CharacterData>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (golpeado)
        {
            tiempoInevencible();
        }
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
                        cliente.disponible = false;
                        Bebida.BebidaTipo tipo = characterData.inventario[i].bebidaTipo;
                        characterData.inventario[i] = null;
                        cliente.servido = true;
                        cliente.GetComponentInChildren<ClienteAtendido>().aparece = false;
                        cliente.GetComponentInChildren<ClienteAtendido2>().aparece = false;
                        cliente.GetComponentInChildren<ClienteAtendido3>().aparece = false;
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

    public void tiempoInevencible()
    {
        float aux = .02f;
        if (contador < 3)
        {
            if (!limiteColor)
            {
                spriteRenderer.color -= new Color(0, aux, aux, 0);
                if (spriteRenderer.color.g < .65) limiteColor = true;
            }
            else
            {
                spriteRenderer.color += new Color(0, aux, aux, 0);
                if (spriteRenderer.color.g == 1)
                {
                    limiteColor = false;
                    contador++;
                }
            }
        }
        else
        {
            golpeado = false;
            contador = 0;
        }
    }
}
