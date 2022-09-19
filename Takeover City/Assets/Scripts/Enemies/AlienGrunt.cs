using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGrunt : MonoBehaviour
{
    public GameObject enemy;
    public GameObject start;
    public GameObject end;
    public float velocity = 1f;
    public float journeyLength = 3f;
    
    private MoveEnemy enemyMovement;

    void Start()
    {
        enemyMovement = new MoveEnemy(enemy, start, end, Time.time, true);
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.sideToSideMovement(velocity, journeyLength);
    }
}
