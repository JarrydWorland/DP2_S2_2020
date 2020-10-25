using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A struct containing the data for where to spawn an enemy.
/// </summary>
public struct SpawnData
{
    //Public Read Only Fields------------------------------------------------------------------------------------------------------------------------

    public readonly EEnemy type;
    public readonly EItem item;
    public readonly Vector3 position;

    //Initialisation Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// SpawnData's constructor.
    /// </summary>
    /// <param name="type">The type of enemy to spawn.</param>
    /// <param name="item">The type of item to drop when the enemy dies.</param>
    /// <param name="position">Where to spawn the enemy.</param>
    public SpawnData(EEnemy type, EItem item, Vector3 position)
    {
        this.type = type;
        this.item = item;
        this.position = position;
    }
}
