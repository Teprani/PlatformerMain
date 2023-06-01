using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameObject playerRef;
    // Update is called once per frame
    void Update()
    {

        PickUp();

    }

    void PickUp()
    {
        if (playerRef)
        {
            playerRef.GetComponent<autoCollectibles>().collectible++;
            //playerRef.GetComponentInChildren<Health>().pv += 10;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        playerRef = collision.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerRef = null;
    }
}
