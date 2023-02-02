using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform Respawnpoint;
   
    public float speed = 10;
  
    public float jumpForce = 2;
    
    public float jumpCD = 1;

    public AudioClip DeathClip;

    public AudioClip JumpClip;

    private Rigidbody2D rb;

    private bool hasJumped = false;
   
    private Vector2 playerInput;
    bool isdead=false;

    // Start is called before the first frame update
    void Start()
    {
     
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead)
            return;

        playerInput.x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && !hasJumped)
        {
            rb.AddForce(Vector2.up * jumpForce);
            hasJumped = true; 
            Debug.Log("Player Jumped. Is Jump on CD: " + hasJumped);
            Invoke("ResetJump", jumpCD);
            AudioSource.PlayClipAtPoint(JumpClip, transform.position);
        }
        else
        {
            playerInput.y = rb.velocity.y;
        }
    }

    private void FixedUpdate()
    {
        if (isdead)
            return;

        rb.velocity = playerInput;
        

    }

    void ResetJump()
    {
        hasJumped = false;
        Debug.Log("Jump Cooldown reset. Is Jump on CD: " + hasJumped);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.GetComponent<wall>())
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            GetComponent<SpriteRenderer>().enabled = false;
            isdead = true;
            AudioSource.PlayClipAtPoint(DeathClip, transform.position);
            Invoke("Respawn", 2);
           
        }
    }

    void Respawn()
    {
        rb.gravityScale = 1;
        this.transform.position = Respawnpoint.position;
        GetComponent<SpriteRenderer>().enabled = true;
        isdead = false;
    }

  
}
