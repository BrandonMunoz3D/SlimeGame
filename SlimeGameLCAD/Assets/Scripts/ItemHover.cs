using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHover : MonoBehaviour
{
    public float amplitude = .03f;
    public float speed = 1.5f;

    //position storage variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        //stare starting position of object
        posOffset = transform.position;
    }
    private void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * speed) * amplitude;
        transform.position = tempPos;
        //Vector3 p = transform.position;
        //p.y = amplitude * Mathf.Cos(Time.time * speed);
        //transform.position = p;
    }
}
