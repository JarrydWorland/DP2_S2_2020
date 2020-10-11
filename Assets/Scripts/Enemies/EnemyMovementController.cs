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

    [SerializeField] protected float onScreenSpeed;
    [SerializeField] protected float offScreenSpeed;
    [SerializeField] protected float acceleration;

    //Non-Serialized Fields------------------------------------------------------------------------

    protected Enemy enemy;
    protected Vector3 movement;
    protected float currentSpeed;

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        currentSpeed = offScreenSpeed;
        movement = new Vector3(0, currentSpeed, 0);
    }

    //Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// FixedUpdate() is run at a fixed interval independant of framerate.
    /// </summary>
    protected void FixedUpdate()
    {
        CheckPosition();
        Move();
    }

    //Recurring Methods (FixedUpdate())--------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Checks the current speed of the enemy based on its position.
    /// </summary>
    public void CheckPosition()
    {
        float targetSpeed = (enemy.IsOnScreen ? onScreenSpeed : offScreenSpeed);

        if (currentSpeed != targetSpeed)
        {
            currentSpeed += acceleration * Time.fixedDeltaTime * (currentSpeed < targetSpeed ? +1 : -1);
            currentSpeed = Mathf.Clamp(currentSpeed, offScreenSpeed, onScreenSpeed);
            movement = new Vector3(0, currentSpeed, 0);
        }
    }

    /// <summary>
    /// Moves the enemy according to its speed.
    /// </summary>
    private void Move()
    {
        //TODO: complex movement
        transform.Translate(movement * Time.deltaTime);
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
    /// </summary>
    /// <param name="collision">The collision data associated with this event.</param>
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
