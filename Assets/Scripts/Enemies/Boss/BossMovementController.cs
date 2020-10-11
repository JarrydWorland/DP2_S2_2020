using UnityEngine;

/// <summary>
/// Moves bosses that the player has to shoot down.
/// </summary>
public class BossMovementController : EnemyMovementController
{
    //Initialization Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled. 
    /// Awake() runs before Start().
    /// </summary>
    private void Awake()
    {
        enemy = GetComponent<Boss>();
    }

    //Core Recurring Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Calculates the current movement vector.
    /// </summary>
    protected override void CalculateMovement()
    {
        base.CalculateMovement();

        if (enemy.IsOnScreen && Player_Movement.Instance != null)
        {
            // Follow player
            float playerX = Player_Movement.Instance.transform.position.y;
            float myX = transform.position.y;
            float deltaX = myX - playerX;
            movement.x = deltaX;
        }
    }
}
