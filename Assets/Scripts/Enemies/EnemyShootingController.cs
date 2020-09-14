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

    //Non-Serialized Fields------------------------------------------------------------------------

    //private Weapon weapon;

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    private void Awake()
    {
        //weapon = GetComponent<Weapon>();
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
        if (IsReadyToShoot())
        {
            //weapon.Shoot();
        }
    }

    /// <summary>
    /// Checks if the enemy wants to shoot at the player and is ready to shoot at the player.
    /// </summary>
    /// <returns>Whether the enemy will shoot at the player or not.</returns>
    private bool IsReadyToShoot()
    {
        //TODO: check if cooldown of weapon between shots is finished.
        //TODO: if cooldown finished, check if want to shoot
        return false;
    }
}
