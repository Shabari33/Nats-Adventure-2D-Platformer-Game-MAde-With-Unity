
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    public static Playermovement instamce;
    public Rigidbody2D rb;
    public static float mov;
    Animator animator;
    public float Speed;
    AudioSource audioSource;
    public AudioClip clip;
    public float jumpspeed = 10f;
    public Transform feet;
    public LayerMask ground;
  [SerializeField] private int playerhealyh = 3;
    public int  curenthealth;
    public int inchealth;
    public bool lowhealth=false;
    public float nexttime = 1f;
    private float rate;
    public GameObject gameover;
    [SerializeField] int shieldhealth = 3;
    public AudioClip jumpaudio;
    public AudioClip hurt;
    public AudioClip collecting;
    // Start is called before the first frame update
    private void Awake()
    {
        instamce = this;

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("attc", 5f, 5f);
       
    }

    // Update is called once per frame
    void Update()
    {
        mov = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && grounded())
        {
            audioSource.PlayOneShot(jumpaudio);
            rb.velocity = new Vector3(rb.velocity.x, jumpspeed, 0f);
            Debug.Log("Jumping");
            animator.SetTrigger("isjump");

        }


        anim();
        attc();
        slide();
        height();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(mov * Speed * Time.deltaTime, rb.velocity.y, 0f);


    }
    public void anim()
    {
        if (mov > 0)
        {

            animator.SetBool("isidle", false);
            animator.SetBool("isrun", true);
            transform.eulerAngles = new Vector3(0, 0, 0);



        }
        else if (mov < 0)
        {

            animator.SetBool("isidle", false);
            animator.SetBool("isrun", true);

            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            animator.SetBool("isidle", true);
            animator.SetBool("isrun", false);
        }
    }
    void attc()
    {
        if (Input.GetKeyDown(KeyCode.I)&& rate < Time.time)
        {
            animator.SetTrigger("shoot");
            audioSource.PlayOneShot(clip);
            rate = Time.time + nexttime;
        }

    }
    public bool grounded()
    {
        Collider2D groundcheck = Physics2D.OverlapCircle(feet.position, 0.5f, ground);
        if (groundcheck != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Traps" )
        {
            audioSource.PlayOneShot(hurt);

            animator.SetTrigger("isdead");
         

            damage();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fireball")
        {
            audioSource.PlayOneShot(hurt);
            animator.SetTrigger("isdead");
           
            damage();
        }

        if (collision.gameObject.tag == "sea")
        {
            audioSource.PlayOneShot(hurt);
            animator.SetTrigger("isdead");
         

            damage();
        }
        if (collision.gameObject.tag == "Landmine")
        {
            audioSource.PlayOneShot(hurt);
            animator.SetTrigger("isdead");
          

            damage();


        }
        if (collision.gameObject.tag == "Lives" && lowhealth == true&& playerhealyh<=2)
        {
            audioSource.PlayOneShot(collecting);
            Debug.Log(playerhealyh);
            playerhealyh = playerhealyh + 1;
          
            UImanager.Instance.increase(playerhealyh);
          
            Destroy(collision.gameObject);
            if (playerhealyh == 3)
            {
                lowhealth = false;
            }

        }
    
           
           
          
    }
    void slide()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            {
                animator.SetTrigger("slide");
                animator.SetBool("isidle", false);
                rb.AddForce(Vector2.left * Speed);




            }

        }


    }
    public void damage()
    {
        playerhealyh = playerhealyh - 1;
        UImanager.Instance.damageplayer(playerhealyh);
        lowhealth = true;
    }
   
    public void die() { 

            animator.SetTrigger("isdead"); 
            Destroy(this.gameObject);
         

           
            
          
        }
    public void height()
    {
        if (this.gameObject.transform.position.y < -50f)
        {
            
            {
               

                playerhealyh = playerhealyh - 1; 
                UImanager.Instance.damageplayer(playerhealyh);
            }
          
          
        }
    }
    }
  
   


    
