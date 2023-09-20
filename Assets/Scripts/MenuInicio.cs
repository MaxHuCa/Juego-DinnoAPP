using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    public void Tienda()
    {
        SceneManager.LoadScene(2);
    }
    public void Progreso() 
    {
        SceneManager.LoadScene(3);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
