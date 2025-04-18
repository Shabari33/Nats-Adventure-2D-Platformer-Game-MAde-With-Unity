using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class heartscript : MonoBehaviour
{
    public bool istaken = false;
    public GameObject canvas;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            canvas.SetActive(true);
         
        }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.SetActive(false);
    }
}
