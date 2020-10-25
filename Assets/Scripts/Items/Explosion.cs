using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float timer;


    private void Start()
    {
        timer = 5;
    }

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Explosion hit");
        
        if (other.CompareTag("Enemy"))
        {
            //reduce enemy hp to zero
            other.gameObject.GetComponent<Enemy>().HealthController.Health.TakeDamage(26);
        }
    }
}
