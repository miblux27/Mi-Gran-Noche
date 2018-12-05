using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlesMenu : MonoBehaviour
{
    public GameObject[] letras;
    public GameObject jugador;

    public Material materialTeclaDesactivada;
    public Material materialTeclaActivada;

    // Update is called once per frame
    void Update ()
    {
        ComprobarEntradas();
        ComprobarSalidas();
    }

    private void ComprobarEntradas()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CambiarAMaterialNeonTecla(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CambiarAMaterialNeonTecla(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CambiarAMaterialNeonTecla(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CambiarAMaterialNeonTecla(4);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarAMaterialNeonTecla(5);
        }
    }

    private void ComprobarSalidas()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            CambiarAMaterialNormalTecla(0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            CambiarAMaterialNormalTecla(2);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            CambiarAMaterialNormalTecla(1);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            CambiarAMaterialNormalTecla(4);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CambiarAMaterialNormalTecla(5);
        }
    }

    private void CambiarAMaterialNeonTecla(int t)
    {
        Image Image = letras[t].GetComponent<Image>();
        if (Image.material != materialTeclaActivada)
        {
            //Image.material = materialTeclaActivada;
            Debug.Log("Material Neon");
        }
    }
    private void CambiarAMaterialNormalTecla(int t)
    {
        Image Image = letras[t].GetComponent<Image>();
        if (Image.material != materialTeclaDesactivada)
        {
            //Image.material = materialTeclaActivada;
            Debug.Log("Material Normal");
        }
    }
}
