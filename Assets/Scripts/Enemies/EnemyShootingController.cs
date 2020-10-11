using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles whether or not enemies shoot at the player.
/// </summary>
public class EnemyShootingController : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    //Serialized Fields----------------------------------------------------------------------------

    [SerializeField] private float shootingRangeOnYAxis;

    //Non-Serialized Fields------------------------------------------------------------------------

    private Enemy enemy;
    private Weapon weapon;

    //private Weapon weapon;

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        weapon = GetComponentInChildren<Weapon>();
    }

    //Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Update() is run every frame.
    /// </summary>
    private void Update()
    {
        Shoot();
    }

    //Recurring Methods (Update())--------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Checks the enemy's health, and sends it back to the factory if it's dead.
    /// </summary>
    private void Shoot()
    {
        if (enemy.IsOnScreen && weapon.CanShoot() && WantToShoot())
        {
            weapon.Shoot();
        }
    }

    /// <summary>
    /// Checks if the enemy wants to shoot at the player.
    /// </summary>
    /// <returns>Whether the enemy wants to shoot at the player or not.</returns>
    private bool WantToShoot()
    {
        if (GameObject.Find("PlayerChar") != null)
        {
            float deltaY = transform.position.y - Player_Movement.Instance.transform.position.y;
            return deltaY > -shootingRangeOnYAxis && deltaY < shootingRangeOnYAxis;
        }

        return false;
    }
}
