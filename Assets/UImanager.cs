using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Image image;
    public Sprite[] lives;
    public static UImanager Instance;
    public GameObject player;
    public GameObject gameover;
    public GameObject robot;
    public TextMeshProUGUI finalscore;
    public GameObject pausecanvas;
    public GameObject coinimage;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void damageplayer(int health)
    {
        if (health < 0)
        {
            health = 0;
        }
        image.sprite = lives[health];
        if (health == 0)
        {
          Playermovement.instamce.die();  
           
            gameover.SetActive(true);
            pausecanvas.SetActive(false);
            Destroy(player, 1f);
            Destroy(robot, 1f);

            finalscore.text = "Coins Collected:"+collectables.instance.score.ToString();
            collectables.instance.sc.enabled = false;
            coinimage.SetActive(false); 
           

        }
        
    }
    public void increase(int max)
    {
        image.sprite = lives[max];  
    }
  
}
