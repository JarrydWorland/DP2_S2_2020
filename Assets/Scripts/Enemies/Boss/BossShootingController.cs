using UnityEngine;

/// <summary>
/// Handles whether or not bosses shoot at the player.
/// </summary>
public class BossShootingController : MonoBehaviour
{
    //Non-Serialized Fields------------------------------------------------------------------------

    private Weapon weapon;

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    private void Awake()
    {
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
    /// Shoots the weapon if it is able to.
    /// </summary>
    private void Shoot()
    {
        if (weapon.CanShoot() && WantToShoot())
        {
            weapon.Shoot();
        }
    }

    /// <summary>
    /// Checks if the boss wants to shoot at the player.
    /// </summary>
    /// <returns>Whether the boss wants to shoot at the player or not.</returns>
    private bool WantToShoot()
    {
        return true;
    }
}
