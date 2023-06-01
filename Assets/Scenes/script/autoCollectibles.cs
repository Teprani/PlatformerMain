using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoCollectibles : MonoBehaviour
{
    public int collectible = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collectible);
    }
    

}
