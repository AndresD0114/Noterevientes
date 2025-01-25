using System.Collections;
using UnityEngine;

public class seedboost : MonoBehaviour
{
    public float dashSpeed = 30f;         // Velocidad del dash (controla la rapidez)
    public float dashDuration = 0.2f;     // Duración del dash
    private bool isDashing = false;       // Indica si el jugador está en medio de un dash
    private Vector3 dashDirection;        // Dirección en la que se realizará el dash
    private float dashTime = 0f;          // Tiempo restante de dash
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Si el jugador está dashing, actualizar el tiempo del dash
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

    // Método para iniciar el Dash, recibe la dirección como parámetro
    public void Dash(Vector3 direction)
    {
        if (!isDashing)  // Solo realiza el dash si no está ya dashing
        {
            isDashing = true;
            dashDirection = direction.normalized;  // Asegura que la dirección esté normalizada
            dashTime = dashDuration;  // Establece la duración del dash
        }
    }

    // Función para saber si el jugador está en medio del dash
    public bool IsDashing()
    {
        return isDashing;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DashTrigger"))  // Asegúrate de que el objeto tenga la etiqueta "DashTrigger"
        {
            // Iniciar dash en la dirección deseada (por ejemplo, hacia adelante)
            Dash(transform.right);
        }
    }
}
