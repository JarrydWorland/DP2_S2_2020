using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] private Projectile projectile;
    [SerializeField] private float cooldown;

    //Non-Serialized Fields------------------------------------------------------------------------

    private float timer;

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
            timer -= Time.deltaTime;
        }
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Checks if the weapon is able to shoot.
    /// </summary>
    public bool CanShoot()
    {
        return timer <= 0;
    }

    /// <summary>
    /// Shoots the weapon.
    /// </summary>
    public void Shoot()
    {
        Instantiate(projectile, transform.position, transform.parent.rotation);
        projectile.parentTag = transform.parent.tag;

        //Debug.Log("Fired");
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
