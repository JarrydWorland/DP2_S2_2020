using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] private float speed = 5;
    private float timeout = 150;

    //Recurring Methods (Update())-------------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 90);
        Debug.Log("Created");
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        timeout -= 1;
        //Debug.Log(timeout);
        if (timeout <= 1)
            Debug.Log("Death");
            Destroy(this);
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    private void OnBecameInvisible()
    {
        Destroy(this);
    }

}
