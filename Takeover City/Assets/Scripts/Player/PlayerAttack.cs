using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public InputMaster controls;
    public Animator animator;
    public GameObject bulletSpawner;
    public GameObject bullet;
    public GameObject player;

    private bool shotBullet = false;
    private bool shootingButton = false;

    void Awake()
    {
        controls = new InputMaster();
        controls.Gameplay.Shoot.performed += ctx => setShoot();
        //controls.Gameplay.Shoot.canceled += ctx => shootingButton = false;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void setShoot()
    {
        if (!shotBullet)
        {
            animator.SetTrigger("Shoot");
            animator.speed = 1.5f;
            // shootingButton = false;
        }
    }

    public void shootBullet()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletSpawner.transform.position;

        if (player.transform.localRotation.eulerAngles.y == 90f)
        {
            newBullet.GetComponent<PlayerBullet>().rb.velocity = new Vector3(50f, 0f, 0f);
        }
        else if (player.transform.localRotation.eulerAngles.y == 270f)
        {
            newBullet.GetComponent<PlayerBullet>().rb.velocity = new Vector3(-50f, 0f, 0f);
        }
    }

    public void endShot()
    {
        animator.ResetTrigger("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        // setShoot();
    }
}
