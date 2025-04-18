using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class roboattack : MonoBehaviour
{
    private Transform player;
    public int speed = 10;
    public float eyesight;
    Animator animator;
    public GameObject attack;
    public int attackrange;
    public GameObject bullet;
    public float nexttime = 2f;
    private float attackrate;
    public Transform teethobj;
    public LayerMask teeth;
    [SerializeField] private int health = 100;
    public Slider healthSlider;
    AudioSource audioSource;
   public AudioClip fireball;
    public AudioClip deathsound;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
        healthSlider.value = health;
        float distancebetween = Vector2.Distance(this.transform.position, player.position);

        if (distancebetween < eyesight)

        {
            if (transform.position.x < player.position.x)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                animator.SetBool("iswalk", true);
                this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

            }
            else if (transform.position.x > player.position.x)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                animator.SetBool("iswalk", true);
                this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

            }
            if (distancebetween < attackrange && attackrate < Time.time)
            {
                animator.SetBool("iswalk", false);
                animator.SetBool("isattack", true);
                Instantiate(bullet, attack.transform.position, attack.transform.rotation);
                audioSource.PlayOneShot(fireball);
                attackrate = nexttime + Time.time;

            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, eyesight);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attack.transform.position, attackrange);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            health = health - 55;
            Debug.Log(health);
          
        }
        if (collision.gameObject.tag == "Firebullet")
        {
            Destroy(collision.gameObject);
            health = health - 60;
            Debug.Log(health);

        }
        if (health < 0)
        {
            health = 0;
            animator.SetTrigger("isdead");
            audioSource.PlayOneShot(deathsound,2f);
            
            Destroy(this.gameObject, 0.5f);

        }
    }
    
}
   


