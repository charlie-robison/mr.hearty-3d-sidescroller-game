using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody rb;
    public float velocity = 50f;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // moveBullet();
    }

    void moveBullet()
    {
        rb.velocity = new Vector3(velocity, 0f, 0f);
    }

    void growBullet()
    {
        if (transform.localScale.y < 4f)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.09f, transform.localScale.z);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        print(col.tag);

        if (col.tag == "Enemy" || col.tag == "FlyerEnemy")
        {
            Destroy(col.gameObject);
            Destroy(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        growBullet();

        if (counter == 300)
        {
            Destroy(bullet);
        }

        counter++;
    }
}
