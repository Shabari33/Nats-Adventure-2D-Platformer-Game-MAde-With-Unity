using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public Transform player;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
       

            }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        Destroy(this.gameObject,2f);
    }
}
