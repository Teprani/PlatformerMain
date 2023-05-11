using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    [SerializeField] private GameObject Gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Gun.GetComponent<Prejectil>().Droite == false)
        {
            transform.localScale = new Vector2(1, -1);
            Debug.Log("coucou");
        }
        
    }
}
