using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firepointmove : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector2(-1, 1);



        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
