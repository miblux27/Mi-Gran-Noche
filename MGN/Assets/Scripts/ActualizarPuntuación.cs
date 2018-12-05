using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarPuntuación : MonoBehaviour {

    private int score = 0;
    private Text dineroEnPantalla;

    private void Start()
    {
        dineroEnPantalla = gameObject.GetComponentInChildren<Text>();
        dineroEnPantalla.text = score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (score > GameManager.CantidadDinero)
        {
            score--;
            dineroEnPantalla.text = score.ToString();
        }
        else if (score < GameManager.CantidadDinero)
        {
            score++;
            dineroEnPantalla.text = score.ToString();
        }
	}
}
