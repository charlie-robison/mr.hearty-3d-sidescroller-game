using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        print(col.gameObject);
        
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }
}
