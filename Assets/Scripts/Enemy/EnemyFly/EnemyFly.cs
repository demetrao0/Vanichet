using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] private float vida;



    void OnCollisionEnter2D(Collision2D collision)
    {
        //Daño al Player 
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.obj.getDamage();


            Debug.Log("Daño a player");
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        // Destruir enemigo 

        if (collision.gameObject.CompareTag("Bala"))
        {
            getKilled();
        }
    }


    void getKilled()
    {
        gameObject.SetActive(false);
    }


    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            
            getKilled();
        }
    }
}
