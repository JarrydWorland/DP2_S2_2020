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
    /// FixedUpdate() is run at a fixed interval independant of framerate.
    /// </summary>
    private new void FixedUpdate()
    {
        movement = CalculateMovement();
        base.MoveBoss();
        // ^ have adjusted from FixedUpdate to MoveBoss as boss is now moving in a different pattern to regular enemies.
    }

    /// <summary>
    /// Calculates the current movement vector.
    /// </summary>
    /// <returns>The movement vector</returns>
    private Vector3 CalculateMovement()
    {
        Vector3 vector = new Vector3(0, speed, 0);

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Follow player
            float playerX = player.transform.position.y;
            float myX = this.transform.position.y;
            float deltaX = myX - playerX;

            vector.x = deltaX;
        }

        return vector;
    }
}