using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : SerializableSingleton<Player_Movement>
{
    [SerializeField] private float speed;
    public GameObject Player;
    public Camera MainCamera;
    private Vector3 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    private void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += movement * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Shoot
            Debug.Log("Pew Pew!");
            Player.GetComponentInChildren<Weapon>().Shoot();
        }
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        transform.position = viewPos;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
    /// </summary>
    /// <param name="collision">The collision data associated with this event.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision, me is {collision.otherCollider}, other is {collision.collider}");

        if (collision.collider.CompareTag("Item"))
        {
            Debug.Log($"Other is Item");
        }
    }
}
