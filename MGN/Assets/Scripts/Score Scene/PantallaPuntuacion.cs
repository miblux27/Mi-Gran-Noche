using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PantallaPuntuacion : MonoBehaviour
{
    public void SalirAlMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinuarJuego()
    {
        SceneManager.LoadScene(1);
    }
}
