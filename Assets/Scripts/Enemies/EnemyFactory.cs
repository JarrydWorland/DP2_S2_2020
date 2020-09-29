using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A factory class for enemies.
/// </summary>
public class EnemyFactory: Factory<EnemyFactory, Enemy, EEnemy>
{
    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Retrieves an enemy from the pool if there's any available, and instantiates a new one if none are available.
    /// </summary>
    /// <param name="position">The position the enemy should be instantiated at.</param>
    /// <param name="rotation">The Vector3 rotation to be applied to the instantiated enemy.</param>
    /// <param name="type">The type of enemy that you want to retrieve.</param>
    /// <returns>A new instance of Enemy.</returns>
    public Enemy Get(Vector3 position, Vector3 rotation, EEnemy type)
    {
        Enemy result = Get(position, type);
        result.transform.SetPositionAndRotation(result.transform.position, Quaternion.Euler(rotation.x, rotation.y, rotation.z));
        return result;
    }

    /// <summary>
    /// Retrieves an enemy from the pool if there's any available, and instantiates a new one if none are available.
    /// </summary>
    /// <param name="type">The type of enemy that you want to retrieve.</param>
    /// <returns>A new instance of Enemy.</returns>
    public override Enemy Get(EEnemy type)
    {
        Enemy result = base.Get(type);
        result.ItemDrop = ItemFactory.Instance.GetRandomItemType();
        //TODO: if allocating item drops to enemies at random, check if enemy should have an item drop on death, and assign to Enemy.
        //TODO: register with enemy manager if one gets added?
        return result;
    }

    /// <summary>
    /// Handles the destruction of enemies.
    /// </summary>
    /// <param name="enemy">The Enemy to be destroyed.</param>
    /// <param name="type">The type of the Enemy to be destroyed.</param>
    public override void Destroy(Enemy enemy, EEnemy type)
    {
        if (enemy.HealthController.Health.IsDead && enemy.ItemDrop != EItem.None)
        {
            ItemFactory.Instance.Get(enemy.transform.position, enemy.ItemDrop);
        }

        enemy.ItemDrop = EItem.None;
        //TODO: deregister from enemy manager if one gets added and Enemy is registered with it.
        base.Destroy(enemy, type);
    }
}
