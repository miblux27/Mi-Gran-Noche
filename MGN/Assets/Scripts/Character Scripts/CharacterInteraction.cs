using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour {

    public CharacterController2D character;
    public int[] bebidas = new int[3];
    private int iteradorBebidas = 0;

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
            bebidas[iteradorBebidas] = (int)Bebidas.chupito;
            iteradorBebidas ++;
            if (iteradorBebidas >= bebidas.Length) iteradorBebidas = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = false;
    }
}
