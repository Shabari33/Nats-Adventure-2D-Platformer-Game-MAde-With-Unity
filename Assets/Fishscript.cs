using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fishscript : MonoBehaviour
   
{
    public float speed = 10f;
    float mov;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
    private void FixedUpdate()
    {
      transform.Translate(Vector2.right*speed*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fishcol")
        {
            transform.eulerAngles = new Vector3 (0f, 180f, 0f);
        }
        if (collision.gameObject.tag == "right")
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
