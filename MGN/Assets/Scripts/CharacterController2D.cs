using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public int extraJumps = 0;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int bebidaA;

    private Animator animator;
    private int saltosActuales;
    private bool mirandoDerecha = true;
    private float moveInput;
    private Rigidbody2D rgbd;
    private float time = 4f;
    private float dashTime;
    private bool barra;

    private bool isGrounded;
    private bool dashActivado = false;
    private static bool ralentizar = false;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) {
            ralentizar = true;
            animator.SetBool("ralentizado", ralentizar);
        }
        if (collision.GetComponent<Collider2D>().CompareTag("Barra")) barra = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("EnemigoGrupo")) {
            ralentizar = false;
            animator.SetBool("ralentizado", ralentizar);
        }
        if (collision.GetComponent<Collider2D>().CompareTag("Barra")) barra = false;
    }

    private void Update()
    {
        time += Time.deltaTime;
        Mover();
        Saltar();
        cogerBebidaA();
    }

    private void Mover()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        animator.SetBool("ground", isGrounded);
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftControl) && time > cooldownTime)
        {
            //tumbar collider, para pasar por debajo del enemigo || Habilitar\Deshabilitar colliders necesarios.
            time = 0;
            dashActivado = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            dashTime = dashLimit;
            dashActivado = false;
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
        animator.SetFloat("Yspeed", (rgbd.velocity.y < 0) ? -1f : 1f);

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

    private void cogerBebidaA()
    {
        if (barra && Input.GetKeyDown(KeyCode.E) && bebidaA < 3)
        {
                bebidaA++;
        }
    }

    private Vector2 VectorDeSalto()
    {
        float salto = (ralentizar) ? bajarVelovidad * jumpForce : jumpForce;
        return Vector2.up * salto;
    }
}
