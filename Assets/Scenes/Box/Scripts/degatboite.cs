using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class degatboite : MonoBehaviour
{

    bool playerCollide = false;
    float timerDamage = 0;
    [SerializeField] float timeBetweenDamage = 2;
    PlayerHealth playerHealth;
    float dot = 0;
    // Start is called before the first frame update
    void Start()
    {
        timerDamage = timeBetweenDamage;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCollide && dot < 0.5f)
        {
            timerDamage += Time.deltaTime;
            if(timerDamage >= timeBetweenDamage)
            {
                playerHealth.TakeDamage(5);
                timerDamage = 0;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerCollide = true;
            Vector3 test = collision.transform.position - gameObject.transform.position;
            test.Normalize();
            dot = Vector3.Dot(test, Vector3.up);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            playerCollide = false;
            timerDamage = timeBetweenDamage;
        }
    }
}
