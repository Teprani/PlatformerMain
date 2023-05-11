 using UnityEngine;
 using System.Collections;
using UnityEditor.Experimental.GraphView;

public class IA_Enemy : MonoBehaviour {
 
     public Transform Target;
     [SerializeField]private float Range;
     public float Speed;
     private Rigidbody2D rb;
 
 
     // Use this for initialization
     void Start () 
     {
         Target = GameObject.FindGameObjectWithTag("Player").transform;
         rb = GetComponent<Rigidbody2D>();
     }
     
     // Update is called once per frame
     void Update () 
     {
        float disToTarget = Vector2.Distance(rb.position, Target.position);
        Vector2 direction = (Target.position - transform.position).normalized;
        if (disToTarget <= Range)
        {
            if (direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }

            rb.velocity = new Vector2( direction.x * Speed, rb.velocity.y);
        }
     }
 }
