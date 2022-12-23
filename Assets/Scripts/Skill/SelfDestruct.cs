using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public GameObject selfDestructObject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoSelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AutoSelfDestruct()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(selfDestructObject);
    }
}
