using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player obj;

    public GameObject[] corazon; 

    public int lives = 3;

    public bool isGorunded = false;
    public bool isMoving = false;

    public float speed = 5f;
    public float jumpForce = 3f;

    public float movHor;
    public bool verDer = true;

    public LayerMask groundLayer;
  
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;
    

    void Awake()
    {

        obj = this;
       
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        lives = corazon.Length;

    }

    // Update is called once per frame
    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");
        isMoving = (movHor != 0f);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1)  )
            Jump();
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGorunded);
        if (movHor > 0 && !verDer)
        {

        Flip();

        }else if(movHor < 0 && verDer)
        {
            Flip();
        }




        if (lives < 1)
        {
            Destroy(corazon[0].gameObject);
        }
        else if (lives < 2)
        {
            Destroy(corazon[1].gameObject);
        }
        else if (lives < 3)
        {
            Destroy(corazon[2].gameObject);
        }
        
    }

    void Jump()
    {
        if (!isGorunded) return;
        rb.velocity = Vector2.up * jumpForce ;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1<< collision.gameObject.layer) & groundLayer) != 0)
        {
            isGorunded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) !=0)
        {
            isGorunded = false;
        }
    }

    public void Flip(/*float _xValue*/)
    {
        /* Vector3 theScale = transform.localScale;
         if (_xValue < 0)
             theScale.x = Mathf.Abs(theScale.x) * -1;
         else
             if (_xValue > 0)
             theScale.x = Mathf.Abs(theScale.x);
         transform.localScale = theScale;*/
        verDer = !verDer;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
     public void getDamage()
    {
        lives--;
        if (lives <= 0)
        {
            Destroy(corazon[0].gameObject);
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
  


    void OnDestroy()
    {
        obj = null;
    }
}
