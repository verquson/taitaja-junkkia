using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "AUD/Create New Weapon Data", order = 0)]
public class WeaponData : ScriptableObject
{
    public GameObject bulletPrefab;
    public float fireRate = 0.2f; // Weapon Cooldown
    public SoundEffect fireSoundEffect;
    public ParticleSystem muzzleFlash; //Muzzle flash effect
}
