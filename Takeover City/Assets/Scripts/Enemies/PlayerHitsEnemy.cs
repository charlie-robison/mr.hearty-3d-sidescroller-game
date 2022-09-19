using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitsEnemy : MonoBehaviour
{
    public GameObject enemy;
    public bool hitHead = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && !hitHead)
        {
            enemy.GetComponent<EnemyCollisions>().hitBody = true;
            Destroy(col.gameObject);
        }
    }
}
