using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMenuObjeto : MonoBehaviour
{
    public GameObject barra;
    public void ActivarMenu()
    {
        barra.SetActive(true);
        GameManager.juegoEnPausa = true;
        Time.timeScale = 0f;
    }
    public void DesactivarMenu()
    {
        barra.SetActive(false);
        GameManager.juegoEnPausa = false;
        Time.timeScale = 1f; 
    }
}
