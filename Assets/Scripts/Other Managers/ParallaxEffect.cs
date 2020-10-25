using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;
    private float width;
    public float speed = -8f;

    //private float length, initPos;
    //public GameObject cam;
    //public float parallaxEffectAmount;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        width = boxCollider.size.x;
        boxCollider.enabled = false;
        rigidBody.velocity = new Vector2(speed, 0);

        //initPos = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (transform.position.x < -width)
        {
            Reposition();
        }

        //float temp = (cam.transform.position.x * (1 - parallaxEffectAmount));
        //float dist = (cam.transform.position.x * parallaxEffectAmount);

        //transform.position = new Vector3(initPos + dist, transform.position.y, transform.position.z);

        //if (temp > initPos + length) initPos += length;
        //else if (temp < initPos - length) initPos -= length;
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + vector;
    }
}
