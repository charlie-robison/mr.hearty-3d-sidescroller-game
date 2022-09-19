using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterGuy : MonoBehaviour
{
    public GameObject rocket;
    public GameObject spawner;
    private int counter = 0;

    void spawnRocket()
    {
        GameObject newRocket = Instantiate(rocket);
        newRocket.transform.position = spawner.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter % 160 == 0)
        {
            spawnRocket();
        }

        counter++;
    }
}
