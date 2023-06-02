using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score_collectt : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
    public TMP_Text TestText;
    public int NumCollectibles;
    public int collectible = 0;
    void Start()
    {
        
        
    }
    // Update is called once per frame
    void Update()
    {
        NumCollectibles = 0;
        ScoreText.text = " " + collectible;
    }

    public void CollectCollectible()
    {
        collectible++;

    }





}
