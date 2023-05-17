using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloc : MonoBehaviour
{
    [SerializeField] private float lifeTime=5;
    private GameObject Enemy;
    private GameObject Gun;


    //[SerializeField] private GameObject Gun;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime); //detruit le bloc après  seconde lifetime
        Enemy = GameObject.FindGameObjectWithTag("Ennemy");
        Gun = GameObject.FindGameObjectWithTag("Arme");
        Enemy.GetComponent<IA_Enemy>().Target = gameObject.transform;
    }

    // Update is called once per frame
 
    void Update()
    {
       
 
    } // end update
    
    void DestroyProjectile()
    {
        Enemy.GetComponent<IA_Enemy>().Target = GameObject.FindGameObjectWithTag("Player").transform;
        //Gun.GetComponent<Prejectil>().NombreBloc--;
        Destroy(gameObject);

    }
}
