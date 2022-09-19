using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "FlyerEnemy")
        {
            Destroy(bomb);
        }

        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }
}
