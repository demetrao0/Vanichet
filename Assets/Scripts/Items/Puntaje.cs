using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Puntaje : MonoBehaviour
{
    

    public static float puntos;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        puntos = 0;
    }

    private void Update()
    {
        
        textMesh.text = puntos.ToString("0");

        
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        
    }

    
}
