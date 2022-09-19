using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public CharacterController controller;
    public GameObject cannon;
    public GameObject rocket;
    public float velocity = 20f;
    public float angle = 45f;

    private Vector3 rocketVelocity = new Vector3(0f, 0f, 0f);
    private float gravity = -9.81f;
    private bool wasShot = false;

    void Start()
    {
        print(transform.position);
    }

    /* Rotates the rocket at a given angle. */
    void rotateRocket()
    {
        // Rotates rocket to current angle.
        if ((-1 * angle) <= 90f)
        {
            transform.eulerAngles = new Vector3(-1 * angle, -90f, 0f);
        }
    }

    /* Moves the rocket with a given velocity and initial angle. */
    void moveRocket()
    {
        // Applies gravity on the vertical component.
        rocketVelocity.y += gravity * Time.deltaTime;

        // Checks if the rocket was shot.
        if (!wasShot)
        {
            // Sets vertical and horizontal velocity components.
            rocketVelocity.x = -1 * velocity * Mathf.Cos(angle * Mathf.Deg2Rad);
            rocketVelocity.y = velocity * Mathf.Sin(angle * Mathf.Deg2Rad);
            wasShot = true;
        }

        // Moves the rocket with the given velocity.
        controller.Move(rocketVelocity * Time.deltaTime);

        // Recalculates the angle from the vertical velocity component at the given time.
        angle = Mathf.Asin(rocketVelocity.y / velocity) * Mathf.Rad2Deg;
    }

    void checkRocket()
    {
        if (transform.position.z != cannon.transform.position.z)
        {
            Destroy(rocket);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag != "Cannon")
        {
            Destroy(rocket);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rotateRocket();
        moveRocket();
        checkRocket();
    }
}
