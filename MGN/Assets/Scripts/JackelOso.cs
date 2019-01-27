using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackelOso : MonoBehaviour
{

    public GameObject posicionBebida;
    public GameObject cerveza;
    public GameObject target;
    public bool mirandoDerecha = true;

    public float radioDeAccion;

    private int direccionAtaque = 1;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanciaATarget = Vector3.Distance(transform.position, target.transform.position);
        if (distanciaATarget < radioDeAccion)
        {
            animator.SetBool("atacar", true);

        }
        else
        {
            animator.SetBool("atacar", false);
            if(!posicionBebida.activeSelf)posicionBebida.SetActive(true);
        }
    }
    public void lanzarBebida()
    {
        var instancia = Instantiate(cerveza, posicionBebida.transform.position, posicionBebida.transform.rotation);
        instancia.GetComponent<Rigidbody2D>().AddForce(new Vector2(direccionAtaque* Random.Range(6,12), 0),ForceMode2D.Impulse);
        posicionBebida.SetActive(false);
    }

    public void activarBebida()
    {
        posicionBebida.SetActive(true);
    }

    public void actualizarPosicion()
    {
        float direccionTarget = target.transform.position.x - transform.position.x;
        if (direccionTarget < 0)
        {
            direccionAtaque = -1;
            if (mirandoDerecha) flip();

        }
        else
        {
            direccionAtaque = 1;
            if (!mirandoDerecha) flip();
        }
    }

    private void flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }


}
