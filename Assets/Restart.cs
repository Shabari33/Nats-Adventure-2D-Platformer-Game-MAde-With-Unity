using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart()
    {
        SceneManager.LoadScene("Firstlevel");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
