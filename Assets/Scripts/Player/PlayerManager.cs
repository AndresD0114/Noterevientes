using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health = 10f;
    public GameObject deathpanel;
    public GameObject body;
    public Animator animCara;
    public Animator animBody;
    public string nextSceneName; // Asegúrate de configurar este campo en el inspector
    public string firstLevelName = "Menu"; // Nombre del primer nivel
    public string designatedObjectTag = "Teleport"; // Tag del objeto designado para teletransporte
    public string squareTag = "Square"; // Tag del objeto square
    public string tpSceneName = "tpescena2"; // Asegúrate de configurar este campo en el inspector
    public string tpSceneName3 = "tpescena3"; // Asegúrate de configurar este campo en el inspector
    public string triangleTag = "Teleport1"; // Tag del objeto triangle

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health--;

            if (health <= 0)
            {
                animBody.SetTrigger("death");
                animCara.SetTrigger("death");
                TeleportToFirstLevel();
                //deathpanel.SetActive(true);
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

    private void TeleportToNextLevel()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("El nombre de la siguiente escena no está configurado.");
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
            Debug.LogError("El nombre de la escena de teletransporte específica no está configurado.");
        }
    }

    private void TeleportToSpecificScene3()
    {
        if (!string.IsNullOrEmpty(tpSceneName3))
        {
            SceneManager.LoadScene(tpSceneName3);
        }
        else
        {
            Debug.LogError("El nombre de la escena de teletransporte específica no está configurado.");
        }
    }

    public void retry()
    {
        SceneManager.LoadScene("Menu");
    }
}

