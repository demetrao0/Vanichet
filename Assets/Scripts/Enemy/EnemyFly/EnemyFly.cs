using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] private float vida;



    void OnCollisionEnter2D(Collision2D collision)
    {
        //Da�o al Player 
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.obj.getDamage();


            Debug.Log("Da�o a player");
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


    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if (vida <= 0)
        {
            
            getKilled();
        }
    }
}
