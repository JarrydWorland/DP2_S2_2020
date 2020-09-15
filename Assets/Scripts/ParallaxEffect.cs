using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, initPos;
    public GameObject cam;
    public float parallaxEffectAmount;

    void Start()
    {
        initPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffectAmount));
        float dist = (cam.transform.position.x * parallaxEffectAmount);

        transform.position = new Vector3(initPos + dist, transform.position.y, transform.position.z);

        if (temp > initPos + length) initPos += length;
        else if (temp < initPos - length) initPos -= length;
    }
}
