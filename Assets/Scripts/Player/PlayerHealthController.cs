﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monitors the player's health.
/// </summary>
public class PlayerHealthController : SerializableSingleton<PlayerHealthController>
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    //Serialized Fields----------------------------------------------------------------------------

    [SerializeField] private AudioSource PlayerAudio;
    [SerializeField] private AudioClip Explosion;

    //Non-Serialized Fields------------------------------------------------------------------------

    private Health health;

    //Public Properties------------------------------------------------------------------------------------------------------------------------------

    //Basic Public Properties----------------------------------------------------------------------

    /// <summary>
    /// The player's health component.
    /// </summary>
    public Health Health { get => health; }

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled.
    /// Awake() runs before Start().
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
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
    /// Checks the player's health, and destroys the player if it's dead.
    /// </summary>
    private void CheckHealth()
    {
        if (health.IsDead)
        {
            PlayerAudio.clip = Explosion;
            PlayerAudio.Play();
            Destroy(gameObject);
        }
    }
}
