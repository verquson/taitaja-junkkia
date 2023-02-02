using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Portal>())
        {
            other.GetComponent<Portal>().BeginTeleport(this.gameObject, GetComponent<Rigidbody>().velocity.magnitude, true);
        }
    }
}
