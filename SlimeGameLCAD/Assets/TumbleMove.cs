using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleMove : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 10;
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    Vector3 rotationDirection = new Vector3();
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject, 4);
    }

}
