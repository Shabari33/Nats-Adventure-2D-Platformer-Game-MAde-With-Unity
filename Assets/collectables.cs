using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectables : MonoBehaviour
{public static collectables instance;   
    public int score = 0;
    public TextMeshProUGUI sc;
    AudioSource audioSource;
    public AudioClip coins; 
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this; }  
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coins);
            score++;
            sc.text = "Coins:"+score.ToString();
            Destroy(collision.gameObject);

        }
    }
    }