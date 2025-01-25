using System.Collections;
using UnityEngine;

public class seedboost : MonoBehaviour
{
    public float dashSpeed = 30f;         // Velocidad del dash (controla la rapidez)
    public float dashDuration = 0.2f;     // Duraci�n del dash
    private bool isDashing = false;       // Indica si el jugador est� en medio de un dash
    private Vector3 dashDirection;        // Direcci�n en la que se realizar� el dash
    private float dashTime = 0f;          // Tiempo restante de dash
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Si el jugador est� dashing, actualizar el tiempo del dash
        if (isDashing)
        {
            dashTime -= Time.deltaTime;

            // Realizar el dash en pasos
            transform.position += dashDirection * dashSpeed * Time.deltaTime;

            // Terminar el dash cuando el tiempo se agote
            if (dashTime <= 0f)
            {
                isDashing = false;  // Termina el dash
            }
        }
    }

    // M�todo para iniciar el Dash, recibe la direcci�n como par�metro
    public void Dash(Vector3 direction)
    {
        if (!isDashing)  // Solo realiza el dash si no est� ya dashing
        {
            isDashing = true;
            dashDirection = direction.normalized;  // Asegura que la direcci�n est� normalizada
            dashTime = dashDuration;  // Establece la duraci�n del dash
        }
    }

    // Funci�n para saber si el jugador est� en medio del dash
    public bool IsDashing()
    {
        return isDashing;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DashTrigger"))  // Aseg�rate de que el objeto tenga la etiqueta "DashTrigger"
        {
            // Iniciar dash en la direcci�n deseada (por ejemplo, hacia adelante)
            Dash(transform.right);
        }
    }
}
