using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public float health = 1f;
    public GameObject deathpanel;
    public GameObject body;
    public Animator animCara;
    public Animator animBody;
    public string nextSceneName; // Aseg�rate de configurar este campo en el inspector
    public string firstLevelName = "Menu"; // Nombre del primer nivel
    public string designatedObjectTag = "Teleport"; // Tag del objeto designado para teletransporte
    public string squareTag = "Square"; // Tag del objeto square
    public string tpSceneName = "tpescena2"; // Aseg�rate de configurar este campo en el inspector
    public string tpSceneName3 = "tpescena3"; // Aseg�rate de configurar este campo en el inspector
    public string triangleTag = "Teleport1"; // Tag del objeto triangle
    public Image blackScreen; // Imagen negra para la transici�n
    public Image moonImage; // Imagen de la luna
    public float fadeDuration = 2f; // Duraci�n del desvanecimiento
    public float moonDisplayDuration = 3f; // Duraci�n de la visualizaci�n de la imagen de la luna

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health--;

            if (health == 0)
            {
                animBody.SetTrigger("death");
                animCara.SetTrigger("death");
                StartCoroutine(HandleDeath());
            }
        }
        else if (collision.gameObject.CompareTag(designatedObjectTag))
        {
            TeleportToNextLevel();
        }
        else if (collision.gameObject.CompareTag(squareTag))
        {
            TeleportToSpecificScene();
        }
        else if (collision.gameObject.CompareTag(triangleTag))
        {
            TeleportToSpecificScene3();
        }
    }

    private IEnumerator HandleDeath()
    {
        // Activa la imagen negra y la imagen de la luna
        blackScreen.gameObject.SetActive(true);
        moonImage.gameObject.SetActive(true);

        // Desvanece la pantalla a negro
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            Color color = blackScreen.color;
            color.a = Mathf.Lerp(0, 1, t / fadeDuration);
            blackScreen.color = color;
            yield return null;
        }

        // Aseg�rate de que la pantalla est� completamente negra
        Color finalColor = blackScreen.color;
        finalColor.a = 1;
        blackScreen.color = finalColor;

        // Espera durante la duraci�n de la visualizaci�n de la imagen de la luna
        yield return new WaitForSeconds(moonDisplayDuration);

        // Carga el men�
        SceneManager.LoadScene(firstLevelName);
    }

    private void TeleportToNextLevel()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("El nombre de la siguiente escena no est� configurado.");
        }
    }

    private void TeleportToFirstLevel()
    {
        SceneManager.LoadScene(firstLevelName);
    }

    private void TeleportToSpecificScene()
    {
        if (!string.IsNullOrEmpty(tpSceneName))
        {
            SceneManager.LoadScene(tpSceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena de teletransporte espec�fica no est� configurado.");
        }
    }

    private void TeleportToSpecificScene3()
    {
        if (!string.IsNullOrEmpty(tpSceneName3))
        {
            retry();
        }
        else
        {
            Debug.LogError("El nombre de la escena de teletransporte espec�fica no est� configurado.");
        }
    }

    public void retry()
    {
        SceneManager.LoadScene("Menu");
    }
}

