using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeme : MonoBehaviour
{
    public static takeme Instance; 
    public bool istaken=false;
    public GameObject text;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this; }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" && collectables.instance.score > 5)
        {
            istaken = true; 
            gameObject.SetActive(false);
            text.SetActive(true);
            Destroy(text, 2f);
        }
        else
        {
            istaken=false;
            gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);  
    }
}
