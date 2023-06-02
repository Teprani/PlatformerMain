using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Pool : MonoBehaviour
{
    public static Bullet_Pool bulletPoolInstanse;
    [SerializeField] private GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;
    private List<GameObject> bullets;
    // Start is called before the first frame update

    private void Awake()
    {
        bulletPoolInstanse = this;
    }
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        { 
            for (int i = 0; i< bullets.Count; i++)
            {
                if (!bullets [i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
