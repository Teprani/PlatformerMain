using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptscore : MonoBehaviour
{
    
    private int NumCollectibles;
    public int collectible = 0;
    void Start()
    {
        NumCollectibles = 0;
        //ScoreText.text = "Score :" + NumCollectibles;
        //(GameObject.Find("Player").GetComponent<autoCollectibles>().NumCollectibles) ;
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collectible);
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
