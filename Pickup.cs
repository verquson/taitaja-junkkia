using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, Iinteractable
{
  public WeaponData data;

    public void OnInteract()
    {
        GameManager.Instance.Player.equippedWeaponData = data; 
    }
}
