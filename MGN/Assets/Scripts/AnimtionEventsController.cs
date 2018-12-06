using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimtionEventsController : MonoBehaviour {

    public ParticleSystem sparks;
    private void ActivarChispas()
    {
        sparks.gameObject.SetActive(true);
        sparks.Play();
    }
}
