using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningShooter : MonoBehaviour
{
    public GameObject topShooter;
    public GameObject leftShooter;
    public GameObject rightShooter;
    public GameObject bullet;

    public float angle;
    public float angularVelocity;

    private int counter = 0;

    void rotateObject()
    {
        angle += angularVelocity * Time.deltaTime;
        transform.eulerAngles = new Vector3(angle, -90f, 0f);
    }

    void spawnBullet(GameObject shooter, float startingAngle)
    {
        Vector3 bulletVelocity = new Vector3(5 * Mathf.Cos(angle + startingAngle), 5 * Mathf.Sin(angle + startingAngle), 0f);
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = shooter.transform.position;
        newBullet.transform.eulerAngles = new Vector3(angle + startingAngle, 0f, 0f);
        newBullet.GetComponent<Rigidbody>().velocity = bulletVelocity;
    }

    void shootBullets()
    {
        if (counter % 2000 == 0)
        {
            spawnBullet(topShooter, 0f);
        }
        
        if (counter % 2030 == 0)
        {
            spawnBullet(leftShooter, 270f);
        }

        if (counter % 2060 == 0)
        {
            spawnBullet(rightShooter, 90f);
        }

        counter++;
    }


    // Update is called once per frame
    void Update()
    {
        rotateObject();
        shootBullets();
    }
}
