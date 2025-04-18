using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pla : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector3 mov;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mov.x = Input.GetAxisRaw("Horizonral");
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(mov.x, rb.velocity.y, 0);
}
}
