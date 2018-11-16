using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public int extraJumps = 0;
    public bool ralentizar = false;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator animator;
    private int saltosActuales;

    private float moveInput;
    private Rigidbody2D rgbd;
    private Collider2D[] colliders;
    private float time = 4f;
    private float dashTime;

    private bool mirandoDerecha = true;
    private bool isGrounded;
    private bool dashActivado = false;

    private const float bajarVelovidad = 0.4f;
    private const float dashSpeed = 10f;
    private const float dashLimit = 2f;
    private const float cooldownTime = 4f;

    // Use this for initialization

    void Start()
    {
        dashTime = dashLimit;
        rgbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colliders = GetComponents<Collider2D>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        Mover();
        Saltar();
    }

    private void Mover()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftControl) && time > cooldownTime)
        {
            //tumbar collider, para pasar por debajo del enemigo || Habilitar\Deshabilitar colliders necesarios.
            time = 0;
            dashActivado = true;
            animator.SetBool("slided", dashActivado);
            colliders[0].enabled = !dashActivado;
            colliders[1].enabled = dashActivado;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            dashTime = dashLimit;
            dashActivado = false;
            animator.SetBool("slided", dashActivado);
            colliders[0].enabled = !dashActivado;
            colliders[1].enabled = dashActivado;
        }
        else if (dashActivado)
        {
            dashTime -= Time.deltaTime;
            if (time < dashLimit)
            {
                rgbd.velocity = new Vector2(moveInput * dashSpeed * (float)(dashTime / dashLimit), rgbd.velocity.y);
            }
            else
            {
                rgbd.velocity = new Vector2(0, rgbd.velocity.y);
            }
        }
        else
        {
            rgbd.velocity = (ralentizar) ? new Vector2(moveInput * speed * bajarVelovidad, rgbd.velocity.y) : new Vector2(moveInput * speed, rgbd.velocity.y);
        }

        animator.SetFloat("speed", (rgbd.velocity.x != 0) ? 1f : -1f);

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
            Debug.Log("Tocando suelo, saltos actuales = " + saltosActuales);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rgbd.velocity = VectorDeSalto();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && saltosActuales > 0)
        {
            rgbd.velocity = VectorDeSalto();
            saltosActuales--;
            Debug.Log("Saltos actuales = " + saltosActuales);
        }
    }

    private Vector2 VectorDeSalto()
    {
        float salto = (ralentizar) ? bajarVelovidad * jumpForce : jumpForce;
        return Vector2.up * salto;
    }
}
