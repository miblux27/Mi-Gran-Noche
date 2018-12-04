using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Bebida : ScriptableObject
{
    public string itemName;
    public int itemID;
    public Sprite icono;
    public BebidaTipo bebidaTipo;

    public enum BebidaTipo
    {
        chupito = 1,
        cocktail = 2,
        cerveza = 3,
    }
}