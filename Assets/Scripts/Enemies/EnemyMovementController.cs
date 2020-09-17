using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves enemies that the player has to shoot down.
/// </summary>
public class EnemyMovementController : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    //Serialized Fields----------------------------------------------------------------------------

    [SerializeField] private float speed;

    //Non-Serialized Fields------------------------------------------------------------------------

    private Vector3 movement;
    private Enemy enemy;

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    private void Awake()
    {
        movement = new Vector3(0, -speed, 0);
        enemy = GetComponent<Enemy>();
    }

    //Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// FixedUpdate() is run at a fixed interval independant of framerate.
    /// </summary>
    private void FixedUpdate()
    {
        Move();
    }

    //Recurring Methods (FixedUpdate())--------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Moves the enemy according to its speed.
    /// </summary>
    private void Move()
    {
        //TODO: complex movement
        transform.Translate(movement * Time.deltaTime);
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Collision, me is {collision.otherCollider}, other is {collision.collider}");
        if (collision.collider.tag == "Map Bounds")
        {
            //Debug.Log($"Other is Map Bounds");
            EnemyFactory.Instance.Destroy(enemy, enemy.Type);
        }
    }
}
