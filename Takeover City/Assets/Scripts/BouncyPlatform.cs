using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    /* Collision Events. */
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMove>().animator.SetTrigger("Idle");
            col.gameObject.GetComponent<PlayerMove>().animator.ResetTrigger("DoubleJump");
            col.gameObject.GetComponent<PlayerMove>().animator.ResetTrigger("Jump");
            col.gameObject.GetComponent<PlayerMove>().bouncyPlatform = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMove>().animator.SetTrigger("Idle");
            col.gameObject.GetComponent<PlayerMove>().animator.ResetTrigger("Jump");
            col.gameObject.GetComponent<PlayerMove>().bouncyPlatform = true;
        } 
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMove>().animator.ResetTrigger("Idle");
            col.gameObject.GetComponent<PlayerMove>().animator.SetTrigger("Jump");

            col.gameObject.GetComponent<PlayerMove>().bouncyPlatform = false;
        }
    }
}
