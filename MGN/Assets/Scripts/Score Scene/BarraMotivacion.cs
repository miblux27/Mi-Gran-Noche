using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class BarraMotivacion : MonoBehaviour
{
    public Image barraMotivacion;
    public GameObject satisfechos;
    public GameObject insatisfechos;

    float perdida;
    public float fillAmountEstimado;
    public float fillAmountEstimadoSuma;
    public bool sumado;
    // Start is called before the first frame update
    void Start()
    {
        fillAmountEstimadoSuma = 0;
        perdida = Random.Range(0.05f, 0.15f);
        fillAmountEstimado = barraMotivacion.fillAmount-(barraMotivacion.fillAmount * perdida);
        sumado = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fillAmountEstimado);
        if (barraMotivacion.fillAmount > fillAmountEstimado && barraMotivacion.fillAmount > 0 && !sumado)
        {
            barraMotivacion.fillAmount -= 0.01f;
            if (barraMotivacion.fillAmount <= 0)
            {
                SceneManager.LoadScene(0);
                Debug.Log("Me salgo");
            }
        }
        else if(barraMotivacion.fillAmount < fillAmountEstimadoSuma && barraMotivacion.fillAmount<=100 && sumado){
            barraMotivacion.fillAmount += 0.01f;
        }

    }
}
