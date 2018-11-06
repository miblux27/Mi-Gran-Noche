using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public int extraJumps = 0;

    private Animator animator;

    private int saltosActuales;
    private bool mirandoDerecha = true;
    private float moveInput;

    private Rigidbody2D rgbd;

    private bool isGrounded;
    private static bool ralentizar = false;
    private const float bajarVelovidad = 0.4f;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Use this for initialization

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) ralentizar = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) ralentizar = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Mover();
    }

    private void Update()
    {
        Saltar();
    }

    private void Mover()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rgbd.velocity = (ralentizar) ? new Vector2(moveInput * speed* bajarVelovidad, rgbd.velocity.y): new Vector2(moveInput * speed, rgbd.velocity.y);

        if (rgbd.velocity.x != 0) animator.SetFloat("speed", 1f);
        else animator.SetFloat("speed", -1f);

        if (!mirandoDerecha && moveInput > 0)
        {
            Flip();
        }
        else if (mirandoDerecha && moveInput < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void Saltar()
    {
        if (isGrounded)
        {
            saltosActuales = extraJumps;
        }
        if (Input.GetKeyDown(KeyCode.Space) && saltosActuales > 0)
        {
            rgbd.velocity = VectorDeSalto();
            saltosActuales--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rgbd.velocity = VectorDeSalto();
        }
    }

    private Vector2 VectorDeSalto()
    {
        float salto = (ralentizar) ? bajarVelovidad * jumpForce : jumpForce;
        return Vector2.up * salto;
    }
}
