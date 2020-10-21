using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

/// <summary>
/// A health component for anything that needs to track health, durability, etc.
/// </summary>
public class Health : MonoBehaviour
{
	//Private Fields---------------------------------------------------------------------------------------------------------------------------------

	[SerializeField] private bool invincible;
	private float invicibleTimer = 5;
	
	//Serialized Fields----------------------------------------------------------------------------

	[SerializeField] private float maxHealth;

	//Non-Serialized Fields------------------------------------------------------------------------

    [Header("For testing only")]
    [SerializeField] private float currentHealth;

	//Public Properties------------------------------------------------------------------------------------------------------------------------------

	//Basic Public Properties----------------------------------------------------------------------

	/// <summary>
	/// How much health, durability, etc. this entity currently has.
	/// </summary>
	public float CurrentHealth { get => currentHealth; }

    /// <summary>
    /// The maximum health, durability, etc. this entity can have.
    /// </summary>
    public float MaxHealth { get => maxHealth; }


    public void SetInvincible(float timer)
    {
	    invincible = true;
	    invicibleTimer = timer;
    }
    public void Update()
    {
	    //Decrement cooldown
	    if (invicibleTimer > 0)
	    {
		    invicibleTimer -= Time.deltaTime;
	    }
	    else
	    {
		    invincible = false;
	    }
    }

    //Complex Public Properties--------------------------------------------------------------------

    /// <summary>
    /// Checks if health is 0 or less.
    /// </summary>
    /// <returns>Is the object this health class is a component of dead?</returns>
    public bool IsDead
    {
        get
        {
            return currentHealth <= 0;
        }
    }

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    private void Awake()
    {
	    invincible = false;
        Reset();
	}

	//Triggered Methods------------------------------------------------------------------------------------------------------------------------------

	/// <summary>
	/// Damage the object.
	/// </summary>
	/// <param name="amount">The amount of damage to take.</param>
	public void TakeDamage(float amount)
	{
        if (amount <= 0)
        {
            Debug.LogError($"Why is {amount} damage being passed to Health.TakeDamage()? Only a positive value should be passed to TakeDamage().");
        }

        if (!invincible)
        {
	        currentHealth -= Mathf.Min(amount, currentHealth);
        }
        
		OnHealthChanged?.Invoke(currentHealth);
	}

	/// <summary>
	/// Heal the object.
	/// </summary>
	/// <param name="amount">The amount of healing to give.</param>
	public void Heal(float amount)
	{
        if (amount <= 0)
        {
            Debug.LogError($"Why is {amount} damage being passed to Health.Heal()? Only a positive value should be passed to Heal().");
        }

        currentHealth += amount;
        
        OnHealthChanged?.Invoke(currentHealth);
	}

    /// <summary>
    /// Resets health to its starting value.
    /// </summary>
    public void Reset()
    {
		currentHealth = maxHealth;

		OnHealthChanged?.Invoke(currentHealth);
    }

    public delegate void HealthEvent(float currentHealth);
    public event HealthEvent OnHealthChanged;
}
