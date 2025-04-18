using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform ground;
    public float speed;
    public bool isright=true;
    Animator animator;
   public AudioClip audioClip;
    AudioSource audioSource;    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed*Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(ground.position, Vector2.down, 0.5f);
        if(hit.collider == false)
        {
            if(isright )
            {
                transform.eulerAngles=new Vector3(0f, 180f, 0f);
                isright = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                isright = true;
            }

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            animator.SetTrigger("isdead");
            audioSource.PlayOneShot(audioClip);
            Destroy(this.gameObject,0.5f);
        }
    }

}
