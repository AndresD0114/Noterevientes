using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        print("Entre a Jugar");
        SceneManager.LoadScene("tpescena1");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
