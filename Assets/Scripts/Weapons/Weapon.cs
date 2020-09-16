using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

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

        print(timer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanShoot())
                Shoot();
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
    private void Shoot()
    {
        //TODO: spawn bullet.
        print("pew pew!");
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
