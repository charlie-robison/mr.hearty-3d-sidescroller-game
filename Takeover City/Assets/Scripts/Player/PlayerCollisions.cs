using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public Animator animator;
/*
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Flag")
        {
            animator.ResetTrigger("Run");
            animator.ResetTrigger("Jump");
            animator.ResetTrigger("Shoot");
            animator.ResetTrigger("WallGrab");
            animator.SetTrigger("Idle");
            animator.SetTrigger("Celebration");
            Destroy(hit.gameObject);
        }
   } */
}
