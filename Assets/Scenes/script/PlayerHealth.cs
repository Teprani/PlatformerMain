using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    public SpriteRenderer graphics;
    public float invincibilityFlashDelay = 0.2f;

    private int tpcampoint = 0;

    public BarreDeVie healthBar;

    //[SerializeField] GameObject hitboxDMG;

    // Start is called before the first frame update
    void Start()
    {
        // le joueur commence avec toute sa vie
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // test pour voir si ca fonctionne
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(100);
        }
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //StartCoroutine(gameObject.GetComponent<player>().Respawn());
            //currentHealth = 100;

        }
    }

    public void TakeDamage (int damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;  // si on prends des degats ont retire de la vie a la vie actuelle
            healthBar.SetHealth(currentHealth); // pour mettre a jour le visuel de la barre de vie
            isInvincible = true;
            //StartCoroutine(InvincibilityFlash());
            //StartCoroutine(HandleInvincibilityDelay());
        }
    }
    public void Heal(int healAmount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = currentHealth + healAmount;
            healthBar.SetHealth(currentHealth);

            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
                healthBar.SetHealth(currentHealth);
            }
        }
        

    }

    //public IEnumerator InvincibilityFlash()
    //{
    //    while (isInvincible)
    //    {
    //        //hitboxDMG.SetActive(false);
    //        graphics.color = new Color(1f, 1f, 1f, 0f);
    //        yield return new WaitForSeconds(invincibilityFlashDelay);
    //        graphics.color = new Color(1f, 1f, 1f, 1f);
    //        yield return new WaitForSeconds(invincibilityFlashDelay);

    //        //hitboxDMG.SetActive(true);
    //    }
    //    Debug.Log("Coroutine1");
    //}

    //public IEnumerator HandleInvincibilityDelay()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    isInvincible = false;
    //    Debug.Log("Coroutine2");
    //}
}
