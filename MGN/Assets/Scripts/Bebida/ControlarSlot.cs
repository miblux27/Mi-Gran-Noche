using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlarSlot : MonoBehaviour
{
    public Bebida bebida;
    private void Start()
    {
        if (bebida != null)
        {
            gameObject.GetComponentInChildren<Image>().sprite = bebida.icono;
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

}
