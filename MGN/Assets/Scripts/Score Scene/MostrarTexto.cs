using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MostrarTexto : MonoBehaviour
{
    public Text sctext;
    void Update()
    {
        sctext.text = GameManager.CantidadDinero.ToString();
    }

}
