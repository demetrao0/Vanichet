using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public float movHor = 0f;
    public float speed = 3f;
    public bool isGroundFloor = true;
    public bool isGroundFront = false;

    public LayerMask groundLayer;
    public float frontGrndRayDist = 0.25f;
    public float FloorCheckY = 0.52f;
    public float frontCheck = 0.51f;
    public float frontDist = 0.001f;

    public int scoreGive = 50;

    private RaycastHit2D hit;

    [SerializeField] private float vida;
    private Animator animator;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Evita caida 
        isGroundFloor = (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - FloorCheckY, transform.position.z),
            new Vector3(movHor, 0, 0), frontGrndRayDist, groundLayer));

        if (isGroundFloor)
        {
            movHor = movHor * -1;

        }

        //Choque con pared 
        if (Physics2D.Raycast(transform.position, new Vector3(movHor, 0, 0), frontCheck, groundLayer))
        {
            movHor = movHor * -1;
        }

        //Choque con otro enemigo 

        hit = Physics2D.Raycast(new Vector3(transform.position.x + movHor * frontCheck, transform.position.y, transform.position.z),
            new Vector3(movHor, 0, 0), frontDist);
        if (hit != false)
        {
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    movHor = movHor * -1;
                }
            }
        }



    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }


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
            Muerte();
            getKilled();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
    }

}
