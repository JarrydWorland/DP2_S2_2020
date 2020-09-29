using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] private float speed;
    [SerializeField] private float timeout;

    //Recurring Methods (Update())-------------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 90);
        Debug.Log("Created");
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.fixedDeltaTime;
        timeout -= Time.fixedDeltaTime;
        //Debug.Log(timeout);
        if (timeout <= 1)
        {
            Debug.Log("Death");
            Destroy(this.gameObject);
        }
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
