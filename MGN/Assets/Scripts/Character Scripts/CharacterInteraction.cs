using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour {

    public CharacterController2D character;
    public static int NumCocktail, NumChupito, NumCerveza;
    private GameObject Cliente;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = true;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
         if (CharacterData.bebidas.Count < 3)
            {
                if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("BarraCocktail"))
                {
                    //Debug.Log("activado");
                    //ActivarMenuObjeto barra = collision.GetComponent<ActivarMenuObjeto>();
                    //barra.ActivarMenu();
                    Debug.Log("Coger Cocktail");
                    CharacterData.bebidas.Add(Bebidas.cocktail);
                    NumCocktail++;
                }
                else if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("BarraChupito"))
                {
                    Debug.Log("Coger Chupito");
                    CharacterData.bebidas.Add(Bebidas.chupito);
                    NumChupito++;
                }
                else if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("BarraCerveza"))
                {
                    Debug.Log("Coger cerveza");
                    CharacterData.bebidas.Add(Bebidas.cerveza);
                    NumCerveza++;
                }
            }
        if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Cliente"))
        {
            MovimientoCliente cliente = collision.GetComponent<MovimientoCliente>();
            if (!cliente.atendido)
            {
                cliente.atendido = true;
                Debug.Log("Cliente Atendido");
            }
            else if (!cliente.servido)
            {
                if (CharacterData.bebidas.Contains(cliente.bebida))
                {
                    if (cliente.bebida == Bebidas.cocktail) {
                        NumCocktail--;
                    }
                    if (cliente.bebida == Bebidas.chupito)
                    {
                        NumChupito--;
                    }
                    if (cliente.bebida == Bebidas.cerveza){
                        NumCerveza--;
                    }
                    
                    cliente.servido = true;
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
