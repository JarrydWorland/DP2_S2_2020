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

    [SerializeField] protected float speed;

    //Non-Serialized Fields------------------------------------------------------------------------

    protected Vector3 movement;
    protected Enemy enemy;
    float xOrigin, xOffset, yOrigin, yOffset;
    float magnitude, frequency;

    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    private void Awake()
    {
        movement = new Vector3(0, speed, 0);
        enemy = GetComponent<Enemy>();
        magnitude = Random.Range(0f, 0.5f);
        frequency = Random.Range(-1f, 2f);
    }

    private void Start()
    {
        xOrigin = this.transform.position.x;
        yOrigin = this.transform.position.y;
    }

    //Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// FixedUpdate() is run at a fixed interval independant of framerate.
    /// </summary>
    protected void FixedUpdate()
    {
        MoveEnemy();
    }

    //Recurring Methods (FixedUpdate())--------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Moves the enemy according to its speed.
    /// </summary>
    protected void MoveBoss()
    {
        //TODO: complex movement
        transform.Translate(movement * Time.deltaTime);
    }

    private void MoveEnemy()
    {
        Vector3 pos = this.transform.position;
        xOffset -= Time.deltaTime * -speed; // move towards the player
        yOffset = Mathf.Sin(1 * Mathf.PI * Time.time) * magnitude; // move up and down
        pos.x = xOrigin + xOffset;
        pos.y = yOrigin + yOffset;
        this.transform.position = pos;
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
