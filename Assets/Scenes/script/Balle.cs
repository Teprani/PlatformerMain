using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    [SerializeField] private int BulletSpeed = 10 ;
    [SerializeField] private int Dommage = 10;
    public Rigidbody2D rb;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject balle;
    [SerializeField] private GameObject Gun;
    [SerializeField] private bool go;

    // Start is called before the first frame update
    void Start()
    {

        rb.gravityScale = 0;
        Invoke("DestroyProjectile", lifeTime);
        Gun = GameObject.Find("Arme");
    }

    // Update is called once per frame
    void Update()
    {

        if (Gun.GetComponent<Prejectil>().Droite == false && go == false)
        {
            rb.velocity = -transform.right * BulletSpeed;
            go = true;
        }
        else if (Gun.GetComponent<Prejectil>().Droite == true && go == false)
        {
            rb.velocity = transform.right * BulletSpeed;
            go = true;
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            //collision.gameObject.GetComponent<Ennemy>().pv -= Dommage;
            collision.gameObject.GetComponentInChildren<EnemyHealth>().TakeDamage(Dommage);
            collision.gameObject.GetComponentInChildren<EnemyHealth>().StartCoroutine("ShowBar");
            DestroyProjectile();
            Debug.Log("beh");
        }
        else DestroyProjectile();
    }
}
