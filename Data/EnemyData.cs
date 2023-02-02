using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "AUD/Create New Enemy Data", order = 0)]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public int MaxHealth;
    public SoundEffect OnTakeDamageSE;
    public SoundEffect OnDeathSE;
}
