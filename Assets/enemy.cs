using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class enemy : MonoBehaviour
  
{
    public int health = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(health == 0)
        {
            die();
        }  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        while (true)
        {
            if (collision.gameObject.tag == "Player")
            {
                health--;
                Debug.Log("Destroying");

            }
        }
    }
    public void die()
    {
        Destroy(this. gameObject);
      
    }
}
