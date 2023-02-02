using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "AUD/Create New Bullet Data", order = 0)]
public class BulletData : ScriptableObject
{
    public string BulletName;
    public int BulletDamage = 50;
    public GameObject hitParticleSystem;
    public float bulletForce = 100f;
}
