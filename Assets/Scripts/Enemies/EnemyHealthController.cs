using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monitors the enemy's health and calls EnemyFactory to handle its destruction if it dies.
/// </summary>
public class EnemyHealthController : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    //Serialized Fields----------------------------------------------------------------------------

    //Non-Serialized Fields------------------------------------------------------------------------

    private Enemy enemy;
    private Health health;

    //Public Properties------------------------------------------------------------------------------------------------------------------------------

    //Basic Public Properties----------------------------------------------------------------------

    /// <summary>
    /// The enemy's health component.
    /// </summary>
    public Health Health { get => health; }

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        health = GetComponent<Health>();
    }

    //Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Update() is run every frame.
    /// </summary>
    private void Update()
    {
        CheckHealth();
    }

    //Recurring Methods (Update())--------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Checks the enemy's health, and sends it back to the factory if it's dead.
    /// </summary>
    private void CheckHealth()
    {
        if (health.IsDead)
        {
            ItemFactory.Instance.GetRandomItem(transform.position);
            EnemyFactory.Instance.Destroy(enemy, enemy.Type);
        }
    }
}
