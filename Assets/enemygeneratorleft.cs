using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygeneratorleft : MonoBehaviour
{
    public GameObject left;
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
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            Vector3 pos = new Vector3(12.56729f, -2.403622f, 0f);
            Instantiate(left, pos, Quaternion.identity);
        }
    }
}
