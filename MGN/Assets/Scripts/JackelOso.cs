using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackelOso : MonoBehaviour
{

    public GameObject posicionBebida;
    public GameObject cerveza;
    public GameObject target;

    public float radioDeAccion;

    private int direccionAtaque = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanciaATarget = Vector3.Distance(transform.position, target.transform.position);
        if (distanciaATarget < radioDeAccion)
        {
            float direccionTarget = target.transform.position.x - transform.position.x;
            if (direccionTarget < 0)
            {
                direccionAtaque *= -1;
            }
            else
            {
                direccionAtaque *= -1;
            }
        }
    }
    public void lanzarBebida()
    {
        var instancia = Instantiate(cerveza, posicionBebida.transform.position, posicionBebida.transform.rotation);
        instancia.GetComponent<Rigidbody2D>().AddForce(new Vector2(direccionAtaque*10, 0),ForceMode2D.Impulse);
        posicionBebida.SetActive(false);
    }

    public void activarBebida()
    {
        posicionBebida.SetActive(true);
    }
}
