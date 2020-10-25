using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A container for all enemy-specific component classes that comprise an enemy for easy referencing from manager classes.
/// </summary>
public class Enemy : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] private EEnemy type;

    //Non-Serialized Fields------------------------------------------------------------------------

    private EnemyHealthController healthController;
    private EnemyMovementController movementController;
    private EnemyShootingController shootingController;
    private EItem itemDrop;

    //Public Properties------------------------------------------------------------------------------------------------------------------------------

    //Basic Public properties----------------------------------------------------------------------

    /// <summary>
    /// The item this enemy should drop if the player kills it.
    /// </summary>
    public EItem ItemDrop { get => itemDrop; set => itemDrop = value; }

    /// <summary>
    /// The enemy's EnemyHealthController component.
    /// </summary>
    public EnemyHealthController HealthController { get => healthController; }

    /// <summary>
    /// The enemy's EnemyMovementController component.
    /// </summary>
    public EnemyMovementController MovementController { get => movementController; }

    /// <summary>
    /// The enemy's EnemyShootingController component.
    /// </summary>
    public EnemyShootingController ShootingController { get => shootingController; }

    /// <summary>
    /// The type of enemy this enemy is.
    /// </summary>
    public EEnemy Type { get => type; }

    //Complex Public Properties--------------------------------------------------------------------

    /// <summary>
    /// Checks if the enemy is on screen.
    /// </summary>
    /// <returns>Is the enemy on screen?</returns>
    public bool IsOnScreen
    {
        get
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
            return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        }
    }

//Initialisation Methods-------------------------------------------------------------------------------------------------------------------------

/// <summary>
/// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
/// Awake() runs before Start().
/// </summary>
protected void Awake()
    {
        healthController = GetComponent<EnemyHealthController>();
        movementController = GetComponent<EnemyMovementController>();
        shootingController = GetComponent<EnemyShootingController>();
    }
}
