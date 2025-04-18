using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class babyfollow : MonoBehaviour
{
    public Transform player;
    public float eyesight;
    public float speed;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > player.position.x)
        {
            animator.SetTrigger("iswalk");
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (transform.position.x < player.position.x)
        {
            animator.SetTrigger("iswalk");
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
