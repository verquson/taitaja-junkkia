using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LootboxManager : MonoBehaviour
{
    public ItemData[]Items;
    public TextMeshProUGUI boxContentsTxt;

    public void OpenLootbox()
    {
        List<ItemData> droppeditems = new List<ItemData>();

        for (int i = 0; i < 4; i++)
        {
            droppeditems.Add(Items[Random.Range(0, Items.Length)]);
        }

        foreach (ItemData item in droppeditems)
        {
            boxContentsTxt.text += "\n" + item.ItemName + ", Rarity: " + item.Rarity ;
        }
    }
}
