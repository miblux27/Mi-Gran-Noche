using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CervezaArma : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject instancia = Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
