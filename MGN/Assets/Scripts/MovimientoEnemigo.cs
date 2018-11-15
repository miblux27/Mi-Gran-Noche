using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    private float velocidad = 11.0f;
    private Vector3 velocity = Vector3.zero;

    public Transform minRange;
    public Transform maxRange;

    public Transform myTransform;

    private int rebota = 1;
    private Animator animator;
    private Rigidbody2D rgbd;
    private bool mirandoDerecha = true;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
        InvokeRepeating("Bloquear", 10.0f, 10.0f);
    }

    // Called before Update
    private void FixedUpdate()
    {

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(velocidad * rebota, rgbd.velocity.y);
        // And then smoothing it out and applying it to the character
        rgbd.velocity = Vector3.SmoothDamp(rgbd.velocity, targetVelocity, ref velocity, 0.05f);

        if (rebota > 0)
        {
            rgbd.velocity = new Vector2(velocidad, 0);
        }
        else rgbd.velocity = new Vector2(-velocidad, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    private void Mover()
    {

        if (mirandoDerecha && myTransform.position.x > maxRange.position.x ||
            !mirandoDerecha && myTransform.position.x < minRange.position.x)
        {
            Flip();
            rebota = -rebota;

        }

       
    }

    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = this.transform.localScale;
        escala.x *= -1;
        myTransform.localScale = escala;
    }

    private void Bloquear() {
        velocidad = 0.0f;
        animator.SetBool("bloquear", true);
        Invoke("Volver", 3.5f);
    }

    private void Volver() {
        animator.SetBool("bloquear", false);
        velocidad = 11.0f;
    }
}
