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
    /// Get a random item at a specified position.
    /// </summary>
    /// <param name="position">The position to spawn the item at.</param>
    /// <returns>A random item.</returns>
    public Item GetRandomItem(Vector3 position)
    {
        List<EItem> keys = new List<EItem>(prefabs.Keys);
        return Get(position, keys[Random.Range(0, keys.Count)]);
    }

    /// <summary>
    /// Get a random item,
    /// </summary>
    /// <returns>A random item.</returns>
    public Item GetRandomItem()
    {
        List<EItem> keys = new List<EItem>(prefabs.Keys);
        return Get(keys[Random.Range(0, keys.Count)]);
    }
}
