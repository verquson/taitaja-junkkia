using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    public float rayLenght = 1;
    public LayerMask mask;
    public Transform rayPosition;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DoInteractionRaycast();
        }
    }

    void DoInteractionRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayPosition.position, rayPosition.forward, out hit, rayLenght, mask))
        {
            GameObject hitObj = hit.collider.gameObject;

            Debug.Log("HIT: ");

            if (hitObj.GetComponent<Iinteractable>() != null)
            {
                hitObj.GetComponent<Iinteractable>().OnInteract();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(rayPosition.position, rayPosition.forward * rayLenght);
    }
  
}
