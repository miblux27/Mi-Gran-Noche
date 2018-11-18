using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public int extraJumps = 0;
    public bool ralentizar = false;
    public static float time = 4f;
    public const float cooldownTime = 4f;
    

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator animator;
    private int saltosActuales;

    private float moveInput;
    private Rigidbody2D rgbd;
    private Collider2D[] colliders;

    private bool mirandoDerecha = true;
    private bool isGrounded;
    private bool slideActivado = false;

    private const float bajarVelovidad = 0.4f;
    private const float slideSpeed = 10f;
    private const float slideLimit = 2f;
    private float slideTime;
    

    // Use this for initialization

    void Start()
    {
        slideTime = slideLimit;
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
            slideActivado = true;
            animator.SetBool("slided", slideActivado);
            colliders[0].enabled = !slideActivado;
            colliders[1].enabled = slideActivado;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            slideTime = slideLimit;
            slideActivado = false;
            animator.SetBool("slided", slideActivado);
            colliders[0].enabled = !slideActivado;
            colliders[1].enabled = slideActivado;
        }
        else if (slideActivado)
        {
            slideTime -= Time.deltaTime;
            if (time < slideLimit)
            {
                rgbd.velocity = new Vector2(moveInput * slideSpeed * (float)(slideTime / slideLimit), rgbd.velocity.y);
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
