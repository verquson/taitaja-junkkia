using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData data;

    public void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletForce);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Portal")
            return;

        if (collision.gameObject.GetComponent<EnemyController>())
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(data.BulletDamage);
        }

        
        // Synnytet‰‰n hit particle effekti kun ammutaan jotain objektia
        // Collision.GetContact(0).point on piste johon ammuttiin (samalla tapaa kuin raycastissa)
        // GetContact(0).normal on kontatki pisteen normal -value, jota voidaan rotaatiossa ottaa huomioon
        Instantiate(data.hitParticleSystem, collision.GetContact(0).point, Quaternion.LookRotation(collision.GetContact(0).normal));

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Portal>())
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Portal>().BeginTeleport(this.gameObject, data.bulletForce, true);
        }
    }
}
