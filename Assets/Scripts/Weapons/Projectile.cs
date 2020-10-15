using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Private Fields---------------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    private float speed;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float timeout;

    //Private Properties-----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Checks if the enemy is on screen.
    /// </summary>
    /// <returns>Is the enemy on screen?</returns>
    private bool IsOnScreen
    {
        get
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
            return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        }
    }

    // Public Fields --------------------------------------------------------------------------------------------------------------------------------

    public string parentTag;

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
        //Debug.Log($"Projectile collision, this tag: {this.transform.parent.tag}, collider tag: {collider.tag}");

        if (collider.tag == parentTag) return;

        if (IsOnScreen)
        {
            Debug.Log(collider.tag + ", " + parentTag);
            
            if (collider.tag == "Enemy" && parentTag == "Player")
                collider.gameObject.GetComponent<Enemy>().HealthController.Health.TakeDamage(damage);
            else if (collider.tag == "Player" && parentTag == "Enemy")
                PlayerHealthController.Instance.Health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}