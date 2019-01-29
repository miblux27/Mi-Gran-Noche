using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcabarNivel : MonoBehaviour
{
    #region Singleton

    public static AcabarNivel instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private float tiempo;

    private int clientesAtendidos = 0;

    void Start()
    {
        clientesAtendidos = 0;

        int ronda = GameManager.jornada;
        if (ronda == 0)
        {
            tiempo = 210f;
        }
        if (ronda >= 1)
        {
            tiempo = 210f;
        }
    }

    private void Update()
    {
        tiempo -= Time.deltaTime;
        if (tiempo <= 0)
        {
            GameManager.jornada++;
            SceneManager.LoadScene(2);
        }
    }

    public int ClientesAtendidos ()
    {
        return clientesAtendidos;
    }

    public void AtenderCliente()
    {
        clientesAtendidos++;
        Debug.Log("Clientes atendidos: " + clientesAtendidos);
    }

}
