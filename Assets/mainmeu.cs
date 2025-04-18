using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmeu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void play()
    {
        SceneManager.LoadScene("Firstlevel");
    }
    public void controlls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void quit()
    {
        Application.Quit();
    }
}

