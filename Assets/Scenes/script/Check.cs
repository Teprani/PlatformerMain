using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position; // respawn au début du jeu
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
       else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}
