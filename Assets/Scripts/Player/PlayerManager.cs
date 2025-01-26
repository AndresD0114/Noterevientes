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
    public string nextSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health--;

            if (health <= 0)
            {
                animBody.SetTrigger("death");
                animCara.SetTrigger("death");
                //deathpanel.SetActive(true);

            }
        }
    }
    public void retry()
    {
        SceneManager.LoadScene("Menu");
    }
}
