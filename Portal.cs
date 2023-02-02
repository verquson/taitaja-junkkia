using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal connectedPortal; // Yhdistetty portal
    public Transform exitPoint; // portalin exit piste
    public float portalCDTime; // Portal cooldown 
    public SoundEffect PortalSE;

    bool portalOnCooldown = false;

    public void BeginTeleport(GameObject objToTeleport, float objCurrentVelocity, bool setRotation)
    {
        // Jos TÄMÄ portali ei ole cooldownilla, voidaan teleportata
        if (!portalOnCooldown)
        {
            AudioManager.Instance.PlayClipOnce(PortalSE);

            // asetetaan YHDISTETTY portal cooldownille
            connectedPortal.portalOnCooldown = true;

            // Asetetaan objekti joka halutaan teleportata YHDISTETYN portaalin ExiPoint position
            objToTeleport.transform.position = connectedPortal.exitPoint.position;

            // Jos SetRotation of true, käännetään objekti myös portaalin exit pisteen suuntaan
            if (setRotation)
                objToTeleport.transform.rotation = connectedPortal.exitPoint.rotation;

            // Jos objektissa on Rigidbody, lisätään siihen addforce
            if (objToTeleport.GetComponent<Rigidbody>())
            {
                objToTeleport.GetComponent<Rigidbody>().AddForce(connectedPortal.exitPoint.forward * objCurrentVelocity);
            }

            Invoke("ResetPortalCD", portalCDTime);
        }
    }

    void ResetPortalCD()
    {
        connectedPortal.portalOnCooldown = false;
    }

    private void OnDrawGizmos()
    {
        if (connectedPortal != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(exitPoint.position, connectedPortal.exitPoint.position);
        }
    }
}
