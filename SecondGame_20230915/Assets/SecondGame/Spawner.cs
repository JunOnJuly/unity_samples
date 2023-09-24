using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] dropPrefab;

    public float interval = 0.2f;
    public float xRange = 39;
    public float zRange = 19;
    float term;

    // Start is called before the first frame update
    void Start()
    {
        term = interval;
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;
        if (term >= interval)
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-xRange, xRange);
            pos.y = 20;
            pos.z += Random.Range(-zRange, zRange);
            int dropType = Random.Range(0, dropPrefab.Length);
            Instantiate(dropPrefab[dropType], pos, transform.rotation);
            term -= interval;
        }
    }
}
