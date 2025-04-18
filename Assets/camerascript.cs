using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camerascript : MonoBehaviour
{ public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position  =new Vector3 (player.position.x,player.position.y,transform.position.z);
    }
}
