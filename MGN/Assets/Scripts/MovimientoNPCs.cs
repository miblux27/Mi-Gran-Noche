using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNPCs : MonoBehaviour {

    protected bool mirandoDerecha = true;

    protected void flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

}
