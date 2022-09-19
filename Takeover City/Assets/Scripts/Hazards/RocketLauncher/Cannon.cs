using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float angle;
    public float rocketAngle;
    public float angularVelocity;

    void Start()
    {
        rocketAngle = angle;
    }

    /* Rotates cannon in a semi-circle. */
    void rotateCannon()
    {
        // Checks if angle has hit its limits.
        if (Mathf.Floor(angle) == 90f || Mathf.Floor(angle) == 0f)
        {
            angularVelocity *= -1;
        }

        // Sets the angle from the angular speed and time.
        angle += angularVelocity * Time.deltaTime;
        rocketAngle -= angularVelocity * Time.deltaTime;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    // Update is called once per frame
    void Update()
    {
        rotateCannon();
    }
}
