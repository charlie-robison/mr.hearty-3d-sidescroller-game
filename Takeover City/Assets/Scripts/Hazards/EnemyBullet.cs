using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bullet;

    private int timer = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(bullet);
        }

        if (col.tag == "Wall")
        {
            Destroy(bullet);
        }
    }

    void Update()
    {
        if (timer % 250 == 0 && timer != 0)
        {
            Destroy(bullet);
        }

        timer++;
    }
}
