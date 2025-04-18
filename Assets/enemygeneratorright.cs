using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygeneratorright : MonoBehaviour
{
    public GameObject enemy1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f,5f));
            Vector3 pos = new Vector3(-33.93f, -2.35f, 0f);
            Instantiate(enemy1, pos, Quaternion.identity);
        }
    }
    
}
