using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int currentHealth;
    public BarreDeVie healthBar;
    private SpriteRenderer graphics;
    [SerializeField] GameObject HEALTHBAR;

    // Start is called before the first frame update
    void Start()
    {
        HEALTHBAR.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Object.Destroy(gameObject);
        }

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        healthBar.SetHealth(currentHealth);
        StartCoroutine(ShowBar());
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        
        if(Player.transform.name == "Player")
        {
            TakeDamage(25);
        }
    }
    private IEnumerator ShowBar()
    {
        HEALTHBAR.SetActive(true);
        yield return new WaitForSeconds(5f);
        HEALTHBAR.SetActive(false);
    }
}
