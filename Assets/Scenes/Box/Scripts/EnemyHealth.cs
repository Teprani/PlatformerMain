using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int currentHealth;
    public BarreDeVie healthBar;
    private SpriteRenderer graphics;
    [SerializeField] GameObject HEALTHBAR;
    [SerializeField] public GameObject Ennemy;

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
        if (currentHealth <= 0)
        {
            Object.Destroy(Ennemy);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.transform.name == "Player")
        {
            TakeDamage(100);
            Debug.Log("BEH!!!");
            StartCoroutine(ShowBar());
        }
    }
    private IEnumerator ShowBar()
    {
        Debug.Log("AH!!");
        HEALTHBAR.SetActive(true);
        yield return new WaitForSeconds(5f);
        HEALTHBAR.SetActive(false);
    }
}
