using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlayMenuMusic();
    }

    public void Jugar()
    {
        print("Entre a Jugar");
        AudioManager.instance.PlayGameMusic();
        SceneManager.LoadScene("tpescena1");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
