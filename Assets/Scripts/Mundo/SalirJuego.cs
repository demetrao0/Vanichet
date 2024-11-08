using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirJuego : MonoBehaviour
{
    // Start is called before the first frame update
   public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado.");
    }
}
