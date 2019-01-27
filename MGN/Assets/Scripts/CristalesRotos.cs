using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalesRotos : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem particulas;
    void Start()
    {
        particulas = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!particulas.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
