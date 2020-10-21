using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : SerializableSingleton<CloneController>
{
    // Start is called before the first frame update
    [SerializeField] private float cloneTimer;
    [SerializeField] public GameObject clone;
    private bool isEnabled;

    // Update is called once per frame
    void Update()
    {
        //Decrement cooldown
        if (cloneTimer > 0)
        {
            cloneTimer -= Time.deltaTime;
        }
        else
        {
            Disable();
        }
    }

    public void Enable(float time)
    {
        cloneTimer = time;
        clone.gameObject.SetActive(true);
        isEnabled = true;
    }

    private void Disable()
    {
        clone.gameObject.SetActive(false);
        isEnabled = false;
    }

    public bool IsEnabled()
    {
        return isEnabled;
    }
}
