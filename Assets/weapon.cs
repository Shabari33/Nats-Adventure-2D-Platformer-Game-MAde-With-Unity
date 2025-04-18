using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform gameobject;
    public float nexttime = 1f;
    private float rate;

    public GameObject bullet;
    public GameObject firebullet;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }
    private void attack()
    {
        if(Input.GetKeyDown(KeyCode.I) && collectables.instance.score > 5 &&takeme.Instance.istaken==true && rate < Time.time)
        {
            Instantiate(firebullet,gameobject.position, gameobject.rotation);
            rate = Time.time + nexttime;
        }

        else if  (Input.GetKeyDown(KeyCode.I) && rate < Time.time)
        {
            Instantiate(bullet, gameobject.position, gameobject.rotation);
            rate = Time.time + nexttime;

        }
    }
}
