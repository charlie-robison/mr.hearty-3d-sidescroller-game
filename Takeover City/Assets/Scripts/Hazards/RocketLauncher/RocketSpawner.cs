using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocket;
    public GameObject cannon;

    private int counter = 0;
    
    void spawnRocket()
    {
        GameObject newRocket = Instantiate(rocket);

        // Sets rocket's properties.
        newRocket.transform.position = transform.position;
        newRocket.GetComponent<Rocket>().cannon = cannon;
        newRocket.GetComponent<Rocket>().velocity = 20f;
        newRocket.GetComponent<Rocket>().angle = cannon.GetComponent<Cannon>().rocketAngle;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter % 100 == 0)
        {
            spawnRocket();
        }

        counter++;
    }
}
