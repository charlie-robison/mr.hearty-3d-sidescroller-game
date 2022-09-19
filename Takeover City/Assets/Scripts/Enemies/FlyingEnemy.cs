using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject bomb;
    public GameObject enemy;
    public GameObject start;
    public GameObject end;

    public float velocity;
    public float journeyLength;
    public int bombDropRate;

    private MoveEnemy enemyMovement;
    private int counter = 0;

    void Start()
    {
        enemyMovement = new MoveEnemy(enemy, start, end, Time.time, true);
    }

    void dropBomb()
    {
        if (counter % bombDropRate == 0)
        {
            GameObject newBomb = Instantiate(bomb);
            newBomb.transform.position = new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z);
        }

        counter += 1;
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.sideToSideMovement(velocity, journeyLength);
        dropBomb();
    }
}
