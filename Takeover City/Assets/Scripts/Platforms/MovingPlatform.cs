using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public float velocity = 1f;
    public float journeyLength = 3f;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    /* Moves the platform up/down, left/right, or forward/back based on the platformType. */
    void movePlatform()
    {
        float totalTime = journeyLength / velocity;
        float currentTime = Time.time - startTime;

        // Increments and decrements between currentTime and totalTime and gets the distance covered.
        float distanceCovered = Mathf.PingPong(currentTime, totalTime);

        // Gets a fraction of the distance covered over the entire journey length.
        float fractionOfJourney = distanceCovered / journeyLength;

        // Gets current position on the line between the start and end by returning the fraction of the distance from fractionOfJourney.
        transform.position = Vector3.Lerp(start.transform.position, end.transform.position, fractionOfJourney);
    }
    
    /* Collision Events. */
    void OnTriggerEnter(Collider col)
    {
        // Checks if player is on platform.
        if (col.tag == "Player")
        {
            // Allows the player to move with the platform.
            col.gameObject.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider col)
    {
        // Checks if player is on platform.
        if (col.tag == "Player")
        {
            // Allows the player to move with the platform.
            col.gameObject.transform.parent = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlatform();
    }
}
