using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public List<Bebida> inventario = new List<Bebida>();

    public void addBebida(Bebida b)
    {
        for(int i =0; i < inventario.Count; i++)
        {
            if (inventario[i] == null)
            {
                inventario[i] = b;
                break;
            }
        }
    }
    public void removeBebida(Bebida b)
    {
        for (int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i] == b)
            {
                inventario[i] = null;
                break;
            }
        }
    }
    public void removeBebidaPorPosicion(int b)
    {
                inventario[b] = null;
    }
    public void removeAll()
    {
        for (int i = 0; i < inventario.Count; i++)
        {
            inventario[i] = null;
        }
    }
}
