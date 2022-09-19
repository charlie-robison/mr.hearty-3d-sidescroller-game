using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float angle;
    public float angularVelocity;

    /* Rotates the platform. */
    void rotatePlatform()
    {
        // Checks for angle limits.
        if (Mathf.Floor(angle) == 90f || Mathf.Floor(angle) == -90f)
        {
            // Switches rotation direction.
            angularVelocity *= -1f;
        }

        // Sets the angle of the platform.
        angle += angularVelocity * Time.deltaTime;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    // Update is called once per frame
    void Update()
    {
        rotatePlatform();
    }
}
