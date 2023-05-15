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
    bool trigger;
    //Update is called once per frame
    void Update()
    {
        if(trigger == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);
        }
    }
       
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Camera"))
        {
            trigger = true;
            Movement();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Camera"))
        {
            OnBecameInvisible();
        }
    }
    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
