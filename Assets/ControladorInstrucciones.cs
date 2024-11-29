using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInstrucciones : MonoBehaviour
{

    public GameObject TextoInstruccion;


    // Start is called before the first frame update
    void Start()
    {
        TextoInstruccion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            TextoInstruccion.SetActive(true);

        }
        
    }
}
