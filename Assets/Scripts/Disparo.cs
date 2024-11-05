using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public Transform controladorDisparo;
    public GameObject bala;
    [SerializeField] private float tiemporEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    private void Update()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }


        if (Input.GetButtonDown("Fire2") && tiempoSiguienteAtaque <= 0 )
        {
            //Disparar

            tiempoSiguienteAtaque = tiemporEntreAtaques;

            Disparar();
        }
    }
    private void Disparar()
    
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation); // //controladorDisparo


    }
}

