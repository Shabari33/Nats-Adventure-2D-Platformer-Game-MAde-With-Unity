using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class dialogebox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakertext;
    [SerializeField] private TextMeshProUGUI dialougetext;
    [SerializeField] private string[] speaker;
   [SerializeField][TextArea] private string[] dialougewords;

    private bool dialougeactivated;
    public GameObject dialougebox;
    public int step;
    public TextMeshProUGUI text;
    AudioSource audiosource;
    public AudioClip textaudio;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && dialougeactivated == true && pause.instance.ispaused==false)
        {
            text.enabled = false;
            audiosource.PlayOneShot(textaudio);
            if (step >= speaker.Length)
            {
                dialougebox.SetActive(false);
                step = 0;
            }
            else if(pause.instance.ispaused == false)
            {

                dialougebox.SetActive(true);
                speakertext.text = speaker[step];
                dialougetext.text = dialougewords[step];
                step += 1;
            }
           
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.enabled = true;
        text.text = "Press T To interact";
        

        if (collision.gameObject.tag == "Player")
        {
            dialougeactivated = true;
            


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            text.enabled = false;
            dialougeactivated = false;
        dialougebox.SetActive(false);
       
        Debug.Log("Exited");
    }
}
 
