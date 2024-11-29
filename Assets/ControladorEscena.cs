using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    public string escenaCambio;
    

    public void CambioDeEscena()
    {
        SceneManager.LoadScene(escenaCambio);
    }

    private void Start()
    {




    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            CambioDeEscena();
    }
 }
