using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNivel : MonoBehaviour
{
    public GameObject[] partesNivel;
    public float distanciaMin;
    public Transform puntoFinal;
    public float cantidadInicial;
    private Transform jugador;
    
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < cantidadInicial; i++)
        {
            GenerarPartes();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(jugador.position,puntoFinal.position)<distanciaMin)
        {
            GenerarPartes();
            Destroy(partesNivel, 120f);
        }
    }

    private void Destroy(GameObject[] partesNivel, float v)
    {
        throw new System.NotImplementedException();
    }

    private void GenerarPartes()
    {
        int numRandon = Random.Range(0,partesNivel.Length);
        GameObject nivel = Instantiate(partesNivel[numRandon],puntoFinal.position,Quaternion.identity);
        puntoFinal = BuscarPuntoFin(nivel, "PuntoFinal");
    }

    private Transform BuscarPuntoFin(GameObject partesNivel,
                                     string etiqueta)
    {
        Transform punto = null;
        foreach (Transform ubicacion in partesNivel.transform)
        {
            if (ubicacion.CompareTag(etiqueta))
            {
                punto = ubicacion;
                break;
            }
        }
        return punto;
    }
}
