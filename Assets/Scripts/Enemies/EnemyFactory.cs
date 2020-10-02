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
    /// <param name="type">The type of item the enemy should drop when it dies.</param>
    /// <returns>A new instance of Enemy.</returns>
    public Enemy Get(Vector3 position, Vector3 rotation, EEnemy type, EItem item)
    {
        Enemy result = Get(type);
        result.transform.eulerAngles = rotation;
        result.transform.position = position;
        result.ItemDrop = item == EItem.Random ? ItemFactory.Instance.GetRandomItemType() : item;
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
        EnemyManager.Instance.Register(result);
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
        EnemyManager.Instance.DeRegister(enemy);
        base.Destroy(enemy, type);
    }
}
