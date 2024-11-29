using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDesActivarPausa : MonoBehaviour
{
    public GameObject pausaMenu;

    public float numeroXD = 0;
    // Start is called before the first frame update
    void Start()
    {
        pausaMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (numeroXD == 0 && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button9))
        {
            Time.timeScale = 0f;
            pausaMenu.SetActive(true);
            numeroXD = 100f;
        }
        if (numeroXD != 0f && Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Return))
        {
            pausaMenu.SetActive(false);

            numeroXD = 0;

            Time.timeScale = 1f;

        }


        
    }
}
