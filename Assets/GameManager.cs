using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
    public int NumCollectibles;
    public int collectible = 0;
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        NumCollectibles = 0;
        ScoreText.text = "Score :" + NumCollectibles;
    }

    public void CollectCollectible()
    {
        collectible++;

    }





}
