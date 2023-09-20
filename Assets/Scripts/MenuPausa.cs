using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject btnPausa;
    [SerializeField] private GameObject btnMenu;
    public void Pausa ()
    {
        Time.timeScale = 0f;
        btnPausa.SetActive(false);
        btnMenu.SetActive(true);
    }
    public void Reanudar ()
    {
        Time .timeScale = 1f;
        btnPausa.SetActive(true);
        btnMenu.SetActive(false);
    }
    public void Reiniciar () 
    { 
        Time .timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
