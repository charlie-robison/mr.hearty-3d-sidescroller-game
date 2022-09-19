using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coin;
    public UILabels uiLabels;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerStats>().coins += 1;
            Destroy(coin);
            print(col.gameObject.GetComponent<PlayerStats>().coins);
            uiLabels.updateCoinsLabel(col.gameObject.GetComponent<PlayerStats>().coins);
        }
    }

    void rotate()
    {
        coin.transform.Rotate(0f, 0f, coin.transform.rotation.z + 1, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
    }
}
