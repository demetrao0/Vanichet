using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string escenaCambio;

    public void CambioDeEscena()
    {
        SceneManager.LoadScene(escenaCambio);
    }
}
