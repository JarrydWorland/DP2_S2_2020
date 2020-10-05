using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float timeout;

    //Recurring Methods (Update())-------------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 90);
        //Debug.Log("Created");
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.fixedDeltaTime;
        timeout -= Time.fixedDeltaTime;
        //Debug.Log(timeout);
        if (timeout <= 0)
        {
            //Debug.Log("Death");
            Destroy(this.gameObject);
        }
    }

    //Triggered Methods------------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log($"Collision, other is {collider}");
        //Debug.Log($"this tag: {this.transform.parent.tag}, collider tag: {collider.tag}");
        if (collider.tag != this.gameObject.tag)
        {
            Destroy(gameObject);

            switch (collider.tag)
            {
                case "Enemy":
                    collider.gameObject.GetComponent<Enemy>().HealthController.Health.TakeDamage(damage);
                    break;

                case "Player":
                    collider.gameObject.GetComponent<PlayerHealthController>().Health.TakeDamage(damage);
                    break;
            }
        }
    }
}
