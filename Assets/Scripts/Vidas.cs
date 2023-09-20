using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    [SerializeField] private int vidas;
    private GameObject[] estadoVida;
    public void PerderVida(int indice)
    {
        estadoVida[indice].SetActive(false);
    }
}
