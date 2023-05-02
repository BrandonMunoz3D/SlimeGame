using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlime_Slam : MonoBehaviour
{
    public Transform collisionDetector;
    public KeyCode activateKey = KeyCode.Q;
    public float destroyDelay = 2.0f;

    private GameObject collidedObject;

    //On Key Down, Get animatator
    private void Update()
    {
        if (Input.GetKeyDown(activateKey))
        {
            Debug.Log("Slam Animation Play");
            GetComponent<Animator>().SetTrigger("Slam");
            DestroyCollidedObject();
        }
    }

    //Collided object that is destroyed is the one with the Layer "Slam"
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Slam"))
        {
            Debug.Log("Object collided with Slam collider.");
            collidedObject = other.gameObject;
        }
    }

    //Destroy collided object mentioned earlier
    private void DestroyCollidedObject()
    {
        if (collidedObject != null)
        {
            Debug.Log("Destroyed collided object.");
            Destroy(collidedObject, destroyDelay);
            collidedObject = null;
        }
    }
}
