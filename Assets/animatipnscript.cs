using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatipnscript : MonoBehaviour

{
    private bool allowcol;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
       private void OnCollisionEnter2D(Collision2D collision)
    {
        if (allowcol)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Attack");
               
                Destroy(collision.gameObject, 0.5f); 
            }
        }

    }
}
