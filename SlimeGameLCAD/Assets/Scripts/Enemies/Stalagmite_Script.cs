using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite : MonoBehaviour
{
    [SerializeField] private GameObject stalagmite;

    [SerializeField] private Transform stalagmiteSpawnPosition;

    [SerializeField] private float minShootWaitTime = 1f, maxShootWaitTime = 3f;

    private float waitTime;

    // Start is called before the first frame update
    void Start()
    { 
       waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
       Shoot(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitTime)
        {
            waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(stalagmite, stalagmiteSpawnPosition.transform);
    }
}
