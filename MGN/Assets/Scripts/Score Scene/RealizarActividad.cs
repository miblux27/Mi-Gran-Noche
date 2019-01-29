using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RealizarActividad : MonoBehaviour
{
    public BarraMotivacion barra;

    public void TaskOnClick1()
    {
        SceneManager.LoadScene(1);
    }
    public void TaskOnClick2()
    {
        if (GameManager.CantidadDinero >= 20)
        {
            GameManager.CantidadDinero -= 20;
            SceneManager.LoadScene(1);
        }
    }

    
    public void TaskOnClick3()
    {
        if (GameManager.CantidadDinero >= 30)
        {
            GameManager.CantidadDinero -= 30;
            SceneManager.LoadScene(1);
        }
    }
}

