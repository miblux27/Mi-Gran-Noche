using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CervezaArma : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject instancia = Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        instancia.transform.Rotate(new Vector3(-90f, 0f, 0f));
        Destroy(gameObject);

        if (collision.transform.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<CharacterInteraction>().golpeado)
            {
                collision.gameObject.GetComponent<CharacterInteraction>().golpeado = true;
                collision.gameObject.GetComponent<CharacterData>().removeAll();
            }
            
        }
    }
}
