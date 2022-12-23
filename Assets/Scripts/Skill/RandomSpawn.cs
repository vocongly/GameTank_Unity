using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject RandomBox;
    public Transform h_SpawnRandomBox;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10.0f)
        {
            Instantiate(RandomBox, h_SpawnRandomBox.position, Quaternion.identity);
            timer = 0;
        }
    }
}
