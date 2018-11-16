using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour {

    public CharacterController2D character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = true;
        if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("Barra"))
        {

        }
        else if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("BarraVIP"))
        {

        }
        else if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<Collider2D>().CompareTag("MaquinaDispensadora"))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) character.ralentizar = false;
    }
}
