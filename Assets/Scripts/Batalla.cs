using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Batalla : MonoBehaviour
{
    public void RegresarPartida()
    {
        SceneManager.LoadScene(3);
    }
}
