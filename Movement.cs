using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10; 

    public AudioClip deathClip;
    public VariableJoystick joystick; 
    private Rigidbody rb; 
    public Transform Respawnpoint;
    Vector3 movementDir;

  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDir.x = joystick.Horizontal* speed*Time.deltaTime;
        movementDir.z = joystick.Vertical*speed*Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        rb.AddForce  (movementDir) ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<wall>())
        {
            this.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Invoke("Respawn", 2);
        }
    }

    void Respawn()
    {
        this.transform.position = Respawnpoint.position;
        this.gameObject.SetActive(true);
        rb.velocity = Vector3.zero;
    }

}
