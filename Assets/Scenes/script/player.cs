using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    CapsuleCollider2D cap;
    Rigidbody2D rb;
    SpriteRenderer sr;
    //Animator animController;
    float horizontal_value;
    Vector2 ref_velocity = Vector2.zero;

    float jumpForce = 15f; 
    
    private int LastPressedJumpTime = 0;
    private int LastOnGroundTime = 0;

    bool CheckSphere;
    private Vector2 aidepose;

    private Vector3 respawnPoint;
    public GameObject fallDetector; // detecte la chute du player et se deplace en meme temps

   
    [SerializeField] float moveSpeed_horizontal = 1000.0f;
    [SerializeField] bool is_jumping = false;
    [SerializeField] bool grounded = false;
    [SerializeField] bool is_crouching = false;
    [Range(0, 1)] [SerializeField] float smooth_time = 0.5f;
    CapsuleCollider2D CapsulPlayer;

    private bool isPaused = false;

    [SerializeField] int CountJump = 2;
    
    [SerializeField] GameObject aide;

    // Start is called before the first frame update
    void Start()
    {
        cap = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = 4f;

        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        horizontal_value = Input.GetAxis("Horizontal");

        if (horizontal_value > 0) sr.flipX = false;
        else if (horizontal_value < 0) sr.flipX = true;

        //animController.SetFloat("Speed", Mathf.Abs(horizontal_value));

        if (Input.GetKeyDown(KeyCode.Space) && CountJump > 0 && isPaused == false)
        {
            Jump();
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

 void Jump()
    {
        // Garantit que nous ne pouvons pas appeler Jump plusieurs fois  partir d'une seule pression
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;
        CountJump -= 1;
        

        // On augmente la force appliquee si on tombe
        // Cela signifie que nous aurons toujours l'impression de sauter le meme montant
        float force = jumpForce;
        if (rb.velocity.y < 0)
            force -= rb.velocity.y;


        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

    }

    void FixedUpdate()
    {
        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.deltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.05f);

    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            StartCoroutine(Respawn());
        }
        else if (collision.tag == "checkpoint")
        {
                respawnPoint = transform.position;
        }
    }

    private IEnumerator Respawn()
    {
        transform.position = respawnPoint;
        if (grounded == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            yield return new WaitForSeconds(1);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CountJump = 2;
        grounded = true ;
        /*CapsulPlayer.sharedMaterial.friction = 5;
        CapsulPlayer.enabled = false;
        CapsulPlayer.enabled = true;

        Debug.Log("tu pue");*/

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false ;
        /*CapsulPlayer.sharedMaterial.friction = 0;
        CapsulPlayer.enabled = false;
        CapsulPlayer.enabled = true;*/

    }

    public void SetPause(bool pause)
    {
        isPaused = pause;
    }


}
