using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyBody;
    public GameObject player;
    public Animator animator;
    public bool hitBody = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && col.gameObject.transform.position.y > enemy.transform.position.y && !hitBody)
        {
            animator.SetTrigger("Die");
            enemyBody.GetComponent<PlayerHitsEnemy>().hitHead = true;
        }
    }

    void triggerPlayerJump()
    {
        player.GetComponent<PlayerMove>().animator.SetTrigger("Idle");
        player.GetComponent<PlayerMove>().animator.ResetTrigger("Jump");
    }

    void enemySquashed()
    {
        Destroy(enemy);
    }
}
