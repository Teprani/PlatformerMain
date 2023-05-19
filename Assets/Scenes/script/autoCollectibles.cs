using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoCollectibles : MonoBehaviour
{
    private int collectible = 0; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectibles"))
        {
            Destroy(collision.gameObject);
            
            
            collectible++;
            Debug.Log("Collectibles:" + collectible);
        }
    }
}
