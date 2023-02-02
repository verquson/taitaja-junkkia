using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "NewItemData", menuName = "AUD/Create New Item Data", order = 0)]
public class ItemData : ScriptableObject
{
    public string ItemName;
    [ShowAssetPreview(width:100, height:100)]
    public Sprite ItemIcon;
    public int ItemPrice;
    public Rarity Rarity;
    public Itemtype ItemType;
    [MinMaxSlider(0,1)]
    public float DropChance;
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare, 
    Epic,
    Legendary
}

public enum Itemtype
{
    Weapon,
    Armor,
    Consumable
}