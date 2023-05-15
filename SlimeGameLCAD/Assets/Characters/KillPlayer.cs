using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public GameObject player;
	public Transform respawnPoint;
    public Transform respawnPoint2;
    //Start is called before the first frame update
    void start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.position;
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint2.position;
        }
	}
}
