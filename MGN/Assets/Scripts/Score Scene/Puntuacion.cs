using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    private int clientesAtendidos;
    private int clientesInsatisfechos;

    private int clientesRonda;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.jornada == 0) clientesRonda = GameManager.clientesJornada0;
        else clientesRonda = GameManager.clientesJornada1;

        clientesAtendidos = AcabarNivel.instance.ClientesAtendidos();
        clientesInsatisfechos = clientesRonda - clientesAtendidos;

        // TODO: Dibujar valores en la pantalla

    }
}
