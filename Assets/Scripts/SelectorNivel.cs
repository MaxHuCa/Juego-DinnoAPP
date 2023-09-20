using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorNivel : MonoBehaviour
{
    public void JugarNivel(int numNivel)
    {
        SceneManager.LoadScene(numNivel);
    }
    public void Salir()
    {
        SceneManager.LoadScene(0);
    }
}
