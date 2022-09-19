using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningSpikyEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject center;
    public float angularVelocity;
    public float radius;
    public bool isSpinning;

    private float angle;
    private Vector3 initialPos;

    void Start()
    {
        // Gets initial position and sets the initial angle.
        initialPos = transform.position;
        angle = (3/2) * Mathf.PI;
    }

    /* Rotates the enemy around. */
    void rotateEnemy()
    {
        if (isSpinning)
        {
            transform.Rotate(0f, 45f * Time.deltaTime, 0f);
        }
    }

    /* Moves the enemy in a circle around a center point. */
    void moveEnemy()
    {
        // Sets enemy's position on the circle and sets its angle given the angular velocity.
        transform.position = new Vector3((radius * Mathf.Cos(angle)) + initialPos.x, (radius * Mathf.Sin(angle)) + initialPos.y, initialPos.z);
        angle += angularVelocity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }

    void Update()
    {
        rotateEnemy();
        moveEnemy();
    }
}
