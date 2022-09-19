using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public GameObject platform;
    
    private bool didTouch = false;
    private int counter = 0;
    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            didTouch = true;
        }
    }

    void Update()
    {
        if (didTouch)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }

        if (counter == 500)
        {
            Destroy(platform);
        }
    }
}
