using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float movespeed = 30f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * movespeed;
        Destroy(this.gameObject,1f);
        

    }
}

