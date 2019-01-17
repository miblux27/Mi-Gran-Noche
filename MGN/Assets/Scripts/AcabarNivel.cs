using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcabarNivel : MonoBehaviour
{
    private float tiempo;

    void Start()
    {
        int ronda = GameManager.jornada;
        if (ronda == 0)
        {
            tiempo = 60.0f;
        }
        if (ronda >= 1)
        {
            tiempo = 15.0f;
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

}
