using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float dano;
    

    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            other.GetComponent<Enemy>().TomarDaño(dano);
            Destroy(gameObject);
        }
    }
}
