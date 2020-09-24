﻿using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] private GameObject projectile;
    [SerializeField] private uint cooldown;


    //Non-Serialized Fields------------------------------------------------------------------------

    private uint timer;

    //Initialisation Methods-------------------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        ResetCooldown();
    }

    //Recurring Methods (Update())-------------------------------------------------------------------------------------------------------------------

    private void Update()
    {
        //Decrement cooldown
        if (timer > 0)
        {
            timer--;
        }
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Checks if the weapon is able to shoot.
    /// </summary>
    public bool CanShoot()
    {
        return timer == 0;
    }

    /// <summary>
    /// Shoots the weapon.
    /// </summary>
    public void Shoot()
    {
        Instantiate(projectile, transform.parent.position, transform.parent.rotation, transform.parent);
        Debug.Log("Fired");
        ResetCooldown();
    }

    /// <summary>
    /// Resets the cooldown timer back to its original value.
    /// </summary>
    private void ResetCooldown()
    {
        timer = cooldown;
    }
}