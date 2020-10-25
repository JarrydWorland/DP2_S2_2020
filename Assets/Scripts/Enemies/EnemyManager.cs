using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A manager class keeping track of all enemies.
/// </summary>
public class EnemyManager : SerializableSingleton<EnemyManager>
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------  

    //Non-Serialized Fields------------------------------------------------------------------------                                                    

    private List<Enemy> enemies;

    //Public Properties------------------------------------------------------------------------------------------------------------------------------

    //Basic Public Properties----------------------------------------------------------------------                                                                                                                          

    /// <summary>
    /// All the enemies that have been spawned in the scene.
    /// </summary>
    public List<Enemy> Enemies { get => enemies; }

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        enemies = new List<Enemy>();
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Registers an Enemy with the EnemyManager.
    /// </summary>
    /// <param name="enemy">The enemy to be registered.</param>
    public void Register(Enemy enemy)
    {
        if (!enemies.Contains(enemy))
        {
            enemies.Add(enemy);
        }
    }

    /// <summary>
    /// De-registers an Enemy with the EnemyManager.
    /// </summary>
    /// <param name="enemy">The enemy to be deregistered.</param>
    public void DeRegister(Enemy enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }
}
