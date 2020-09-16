using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] private float speed;

    //Recurring Methods (Update())-------------------------------------------------------------------------------------------------------------------

    private void Start()
    {
        transform.rotation = transform.parent.rotation * Quaternion.Euler(0, 0, 90);
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    private void OnBecameInvisible()
    {
        Destroy(this);
    }
}
