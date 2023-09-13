using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimento")]
    public float suvMovimento;
    public float velMovimiento;
    private float movVertical;
    private float movHorizontal = 0f;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDer = true;

    [Header("Salto")]
    public float fuerzaSalto;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public bool enSuelo;
    public Vector3 dimensionesCaja;
    private bool salto = false;

    [Header("Animación")]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movHorizontal = Input.GetAxisRaw("Horizontal") * velMovimiento;
        animator.SetFloat("HorizontalMov",Mathf.Abs(movHorizontal));
        animator.SetFloat("VerticalMov",rb2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("EnSuelo",enSuelo);
        Mover(movHorizontal * Time.fixedDeltaTime, salto);
        salto = false;
    }

    private void Mover(float mover, bool saltar)
    {
        Vector2 velJugador = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velJugador, ref velocidad, suvMovimento);

        if (mover > 0 && !mirandoDer)
        {
            Giro();
        }
        else if (mover < 0 && mirandoDer)
        {
            Giro();
        }

        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaSalto));

        }
    }

    private void Giro()
    {
        mirandoDer = !mirandoDer;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(controladorSuelo.position, dimensionesCaja);
    }
}
