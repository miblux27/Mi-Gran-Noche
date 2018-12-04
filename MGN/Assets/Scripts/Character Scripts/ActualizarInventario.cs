using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarInventario : MonoBehaviour
{
    public CharacterData characterData;
    public List<GameObject> slotsImagen;
    public void Start()
    {
        actualizarInventario();
    }
    public void actualizarInventario()
    {
        for (int i = 0; i < characterData.inventario.Count; i++)
        {
            if (characterData.inventario[i] == null) { slotsImagen[i].GetComponentInChildren<Image>().sprite = null;}
            else slotsImagen[i].GetComponentInChildren<Image>().sprite = characterData.inventario[i].icono;
        }
    }
    public void Update()
    {
        actualizarInventario();
    }
}
