using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniAlien : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public GameObject enemy;
    public GameObject player;
    
    private Vector3 enemyVelocity = new Vector3(0f, 0f, 0f);
    private float gravity = -9.81f;

    void moveEnemy()
    {
        if (!controller.isGrounded)
        {
            enemyVelocity.y += gravity * Time.deltaTime;
        }

        if (checkDistance())
        {
            enemyVelocity.x = -4f;
        }

        controller.Move(enemyVelocity * Time.deltaTime);
    }

    bool checkDistance()
    {
        float distanceFromPlayerX = (player.transform.position.x - enemy.transform.position.x) * (player.transform.position.x - enemy.transform.position.x);
        float distanceFromPlayerY = (player.transform.position.y - enemy.transform.position.y) * (player.transform.position.y - enemy.transform.position.y);
        float distanceFromPlayer = Mathf.Sqrt(distanceFromPlayerX + distanceFromPlayerY);

        if (distanceFromPlayer <= 30f)
        {
            return true;
        }

        return false;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Destroy(hit.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
    }
}
