using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    Vector3 velocidad;

    Vector3 postante;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        postante = transform.position;
        InvokeRepeating("ActualizarPosicion", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("ascend", (velocidad.y > 0.1f));
        animator.SetBool("falling", (velocidad.y < -0.1f));
    }

    void ActualizarPosicion()
    {
        velocidad = (transform.position - postante);
        postante = transform.position;
    }
    public void Dash()
    {
        animator.SetTrigger("dash");
    }
    public void Morir()
    {
        animator.SetTrigger("death");
    } 
}
