using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyEnemy : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public float velocity = 1f;
    public float journeyLength = 3f;
    public bool isSpinning;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    /* Moves the enemy left and right. */
    void moveEnemy()
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

    void rotateEnemy()
    {
        if (isSpinning)
        {
            transform.Rotate(0f, 45f * Time.deltaTime, 0f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
        rotateEnemy();
    }
}
