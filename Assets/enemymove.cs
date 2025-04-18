using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class enemymove : MonoBehaviour

{
    Rigidbody2D rb;
    public float movespeed;
    public Animator animator;
    private Transform player;
    public float lineofsight;
    public float attackrange;
    public GameObject attack;
    public GameObject Player;
    public GameObject fireball;
    public float nexttime = 1f;
    private float rate;
    public Transform fire;
    [SerializeField] private int health = 100;
    public Slider healthslider;
    public  static enemymove instance;
    AudioSource audioSource;
    public AudioClip fireee;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;    
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = player.GetComponent<AudioSource>();
        

    }
    // Update is called once per frame
    void Update()
    {
        healthslider.value = health;

        float distancefromplayer = Vector2.Distance(player.position, this.transform.position);
        if (distancefromplayer < lineofsight)
        {

            if (transform.position.x < fire.position.x)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, movespeed * Time.deltaTime);
                animator.SetBool("iswalk", true);


            }
            else if (transform.position.x > fire.position.x)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, movespeed * Time.deltaTime);
                animator.SetBool("iswalk", true);

            }




        }

        if (distancefromplayer <= attackrange && rate < Time.time)
        {
            animator.SetTrigger("attack");

            Instantiate(fireball, attack.transform.position, attack.transform.rotation);
            audioSource.PlayOneShot(fireee); 
            rate = Time.time + nexttime;
            animator.SetBool("iswalk", false);



        }



    }













    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineofsight);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attack.transform.position, attackrange);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            health = health - 50;
        }
        if (collision.gameObject.tag == "Firebullet")
        {
            Destroy(collision.gameObject);
            health = health - 60;
        }
        if (health == 0)
        {
            Destroy(this.gameObject,0.5f);
        }
    }
    public void headshoot()
    {
        health = health - 60;
    }
}


