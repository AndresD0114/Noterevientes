using UnityEngine;

public class Moven : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float rampSpeed = 50f;
    private Rigidbody2D rb;
    public bool onRamp = false;

    void Start()
    {
        // Intentar obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        // Si no est� presente, agregarlo din�micamente
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }


   
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ramp"))
        {
            onRamp = true;
            Debug.Log("En la rampa - Acelerando.");

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ramp"))
        {
            Invoke("DesactivarRampa", .2f);
            Debug.Log("Fuera de la rampa - Velocidad normal.");
        }
    }

    void DesactivarRampa()
    {
        onRamp = false;
    }
}

