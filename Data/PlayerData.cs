using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPlayerData", menuName ="AUD/Create New Player Data", order =0)]
public class PlayerData : ScriptableObject
{
    public string PlayerName;
    public int Maxhealth = 100;
    public SoundEffect JumpSound;
}
