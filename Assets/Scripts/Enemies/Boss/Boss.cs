/// <summary>
/// Overrides the Enemy getters to return boss variants.
/// </summary>
public class Boss : Enemy
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    private BossMovementController movementController;
    private BossShootingController shootingController;

    //Basic Public properties----------------------------------------------------------------------

    /// <summary>
    /// The boss' BossMovementController component.
    /// </summary>
    public new BossMovementController MovementController { get => movementController; }

    /// <summary>
    /// The boss' BossShootingController component.
    /// </summary>
    public new BossShootingController ShootingController { get => shootingController; }

    //Initialisation Methods-------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Awake() is run when the script instance is being loaded, regardless of whether or not the script is enabled.
    /// Awake() runs before Start().
    /// </summary>
    private new void Awake()
    {
        base.Awake();
        movementController = GetComponent<BossMovementController>();
        shootingController = GetComponent<BossShootingController>();
    }
}
