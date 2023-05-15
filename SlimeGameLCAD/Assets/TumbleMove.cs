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
    
    // Start is called before the first frame update
    void Start()
    {
        
            StartCoroutine(ShowAndHide(3.0f));
        }
        IEnumerator ShowAndHide(float delay)
        {
            TumbleMove.SetActive(true);
            yield return new WaitForSeconds(delay);
            TumbleMove.SetActive(false);
        
    }

    private static void SetActive(bool v)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Camera"))
        {
            Debug.Log("trigger");
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject, 4);
    }

}
