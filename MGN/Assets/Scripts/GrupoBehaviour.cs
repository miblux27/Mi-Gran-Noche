using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrupoBehaviour : MonoBehaviour
{
    private static bool transparentar = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Player")) transparentar = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Player")) transparentar = false;
    }

    private void FixedUpdate()
    {
        if (transparentar) VolverTransparente();
        else VolverOpaco();
    }

    private void VolverTransparente()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().material.color;

        if (color.a > 0.5f)
        {
            color.a -= (color.a * 0.15f);
            gameObject.GetComponent<SpriteRenderer>().material.color = color;
        }
    }
    private void VolverOpaco()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().material.color;

        if (color.a < 1f)
        {
            color.a += (color.a * 0.15f);
            gameObject.GetComponent<SpriteRenderer>().material.color = color;
        }
    }
}
