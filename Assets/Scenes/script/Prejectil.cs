using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prejectil : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Transform SpawnPointBloc;
    [SerializeField] private GameObject balle;
    [SerializeField] private GameObject bloc;
    [SerializeField] private SpriteRenderer sr;
    public bool Droite;
    public bool Bon_Sens;
    public int NombreBloc = 0;

    public float TimeBetweenSpawns = 1f;
    public float timeSinceSpawn = 0f;
    private int nextSpawn = 0;
    private bool doneSpawning = false;
    private float coolDown = 5;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);



        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x && sr.flipX == false)
        {
            transform.localScale = new Vector2(1, -1);
            transform.rotation = Quaternion.Euler(180f, 0f, -rotZ);

            Droite = true;
            Bon_Sens = true;

        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x && sr.flipX == true)
        {
            transform.localScale = new Vector2(-1, -1);

            Bon_Sens = false;   

        }

        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= transform.position.x && sr.flipX == true)
        {

            transform.localScale = new Vector2(-1, -1);
            transform.rotation = Quaternion.Euler(0f, -180f, -rotZ);

            Droite = false;
            Bon_Sens = true;
            //SpawnPoint.rotation = Quaternion.Euler(0f, 180f, rotZ);
        }
        else
        {
            transform.localScale = new Vector2(1, -1);
            Bon_Sens = false;
        }


        //if (sr.flipX == true)
        //{
        //    transform.rotation = Quaternion.Euler(180f, 0f, -rotZ + offset);
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            if (Bon_Sens)
            {
                Shoot();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Bon_Sens)
            {
                SpawnBloc();
            }

        }

        if (doneSpawning == false)
        {
            timeSinceSpawn += Time.deltaTime;
            if (timeSinceSpawn >= TimeBetweenSpawns)
            {
                //nextSpawn++;
                timeSinceSpawn = 0f;
                //if (nextSpawn >= 2)
                //{
                doneSpawning = true;
                //}
            }
        }


        void Shoot()
        {

            Instantiate(balle, SpawnPoint.position, SpawnPoint.rotation);

        }
        void SpawnBloc()
        {
            if (NombreBloc < 2 && doneSpawning)
            {
                Instantiate(bloc, SpawnPointBloc.position, Quaternion.Euler(0, 0, 180));
                NombreBloc++;
                doneSpawning = false;
                Invoke("nbrBloc", coolDown);
            }

            //if (NombreBloc > 0)
            //{
            //    Destroy(bloc);
            //    Instantiate(bloc, SpawnPointBloc.position, SpawnPointBloc.rotation);
            //    NombreBloc--;
            //}


        }

        

    }
    public void nbrBloc()
    {
        NombreBloc--;

    }
}
