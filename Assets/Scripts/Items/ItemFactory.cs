using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A factory class for item drops.
/// </summary>
public class ItemFactory : Factory<ItemFactory, Item, EItem>
{
    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Get a random item type, with a 50% chance of returning EItem.None.
    /// </summary>
    /// <returns>The EItem value corresponding to a random type of Item.</returns>
    public EItem GetRandomItemType()
    {
        List<EItem> keys = new List<EItem>(prefabs.Keys);
        return Random.Range(0, 2) == 0 ? EItem.None : keys[Random.Range(0, keys.Count)];
    }
}
