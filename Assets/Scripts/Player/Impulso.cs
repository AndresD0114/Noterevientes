using UnityEngine;
using System.Collections;

public class Impulso : MonoBehaviour
{
    public float rampSpeed = 50f;

    public bool onRamp = false;


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
