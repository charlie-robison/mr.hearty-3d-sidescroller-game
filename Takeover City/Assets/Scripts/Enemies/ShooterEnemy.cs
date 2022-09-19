using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public GameObject enemy;
    public GameObject start;
    public GameObject end;
    public GameObject blaster1;
    public GameObject blaster2;
    public GameObject bullet;

    public float velocity;
    public float journeyLength;
    public float bulletFrequency;

    private MoveEnemy enemyMovement;

    void Start()
    {
        enemyMovement = new MoveEnemy(enemy, start, end, Time.time, true);
        animator.speed = bulletFrequency;
    }

    bool checkDistance()
    {
        if (Mathf.Abs(player.transform.position.x - enemy.transform.position.x) <= 60f)
        {
            return true;
        }

        return false;
    }

    void shootBullet1()
    {
        print(checkDistance());

        if (checkDistance())
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = blaster1.transform.position;
        
            if (enemyMovement.getDirection() == -1)
            {
                newBullet.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            else
            {
                newBullet.transform.eulerAngles = new Vector3(0f, 180f, 180f);
            }

            newBullet.GetComponent<Rigidbody>().velocity = new Vector3(enemyMovement.getDirection() * 20f, 0f, 0f);
        }
    }

    void shootBullet2()
    {
        // if (checkDistance())
        // {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = blaster2.transform.position;

            if (enemyMovement.getDirection() == -1)
            {
                newBullet.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            else
            {
                newBullet.transform.eulerAngles = new Vector3(0f, 180f, 180f);
            }

            newBullet.GetComponent<Rigidbody>().velocity = new Vector3(enemyMovement.getDirection() * 20f, 0f, 0f);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.sideToSideMovement(velocity, journeyLength);
    }
}
