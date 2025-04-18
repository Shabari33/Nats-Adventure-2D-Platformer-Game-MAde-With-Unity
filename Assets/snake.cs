using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 33.8f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision .gameObject .tag=="Player") {
            
            animator.SetBool("isattack",true);
            animator.SetBool("isidle", false);
            Debug.Log("snake");
        }

}
    }
