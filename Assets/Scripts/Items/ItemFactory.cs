using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A factory class for item drops.
/// </summary>
public class ItemFactory : Factory<ItemFactory, Item, EItem>
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    //Non-Serialized Fields------------------------------------------------------------------------

    List<EItem> keys;

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Start() is run on the frame when a script is enabled just before any of the Update methods are called for the first time. 
    /// Start() runs after Awake().
    /// </summary>
    protected override void Start()
    {
        base.Start();
        keys = new List<EItem>(prefabs.Keys);
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Get a random item type. Each type has an equal chance of being chosen.
    /// </summary>
    /// <returns>The EItem value corresponding to a random type of Item.</returns>
    public EItem GetRandomItemType()
    {
        return keys[Random.Range(0, keys.Count)];
    }
}
