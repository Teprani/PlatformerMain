using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class autoCollectibles : MonoBehaviour
{
    public Text ScoreText;
    private int NumCollectibles;
    public int collectible = 0;
    void Start()
    {
        NumCollectibles = 0;
        ScoreText.text = "Score :" + NumCollectibles;
        ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collectible);
    }
    

}
