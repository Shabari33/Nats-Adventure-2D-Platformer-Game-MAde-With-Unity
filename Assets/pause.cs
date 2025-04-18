using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
 
{
    public static pause instance;
    public bool ispaused=false;
    public GameObject buttoncanvas;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void paused()
    {
        {
            Time.timeScale = 0f;
            buttoncanvas.SetActive(true);

            ispaused = true;
       
     

        }
    }
  

    public void resume()

    {
        {
            buttoncanvas.SetActive(false);
            Time.timeScale = 1f;
            ispaused = false;

        }
    }
   
  public void Quit()
    {
        Application.Quit(); 
    }
   public void Mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void start()
    {
        SceneManager.LoadScene("Firstlevel");
        
    }
    public void controls()
    {
        SceneManager.LoadScene("Controls");
    }
}
