using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Controller buttons.
    public InputMaster controls;
    private Vector2 move;
    private bool jumpButton = false;

    public GameObject player;
    public Animator animator;
    public CharacterController controller;
    public bool bouncyPlatform = false;
    public bool hitEnemy = false;

    private Vector3 playerVelocity = new Vector3(0f, 0f, 0f);
    private Vector3 wallNormalDirection;

    private float velocity = 6f;
    private float jumpForce = 6f;
    private float gravity = -9.81f;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    
    private bool isJumping = false;
    private bool wallJump = false;
    private bool doubleJump = false;
    private bool isWallJumping = false;

    private int jumpTimer = 0;

    void Awake()
    {
        controls = new InputMaster();

        // Sets move.x to 1, -1, or 0 based on the toggle on controller.
        controls.Gameplay.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctx => move = Vector2.zero;

        // Sets jumpButton to true or false if button is pressed on controller.
        controls.Gameplay.Jump.performed += ctx => jumpButton = true;
        controls.Gameplay.Jump.canceled += ctx => jumpButton = false;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    /* Moves the player left and right based on the buttons pressed. */
    void movePlayer()
    {
        float horizontal = move.x;

        // Changes the direction of the player based on the horizontal input and if not wall jumping.
        if (horizontal != 0f && !wallJump && !isWallJumping)
        {
            // Sets the direction of the player.
            transform.eulerAngles = new Vector3(0f, horizontal * 90, 0f);
        }

        // Checks if the player was jumping.
        if (!isJumping)
        {
            if (horizontal == 0f)
            {
                // Removes run animation.
                animator.ResetTrigger("Run");

                // Checks if on ground or not on a bouncy platform.
                if (controller.isGrounded && !bouncyPlatform)
                {
                    animator.SetTrigger("Idle");
                }
            }
            else
            {
                // Sets run animation.
                animator.SetTrigger("Run");
                animator.ResetTrigger("Idle");
                animator.speed = 1.2f;
            }
       
            // Sets player's x velocity.
            playerVelocity.x = velocity * horizontal;
        }
        else if (isWallJumping || wallJump)
        {
            animator.ResetTrigger("Run");
        }
        else
        {
            animator.ResetTrigger("Run");
            playerVelocity.x = velocity * horizontal;
        }
    }

    /* Adds a jump force if the button is pressed. */
    void jump()
    {
        // Increases player's y velocity by the gravity.
        if (wallJump)
        {
            // Decreases downward acceleration amount when player is attached to the wall.
            playerVelocity.y += (0.3f * gravity) * Time.deltaTime;
        }
        else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        // Checks if space bar was pressed.
        if (jumpButton)
        {
            // Sets the jump buffer counter to 0.2 (amount of leeway time user has to jump right before the player hits the ground).
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            // Decrements the jump buffer counter.
            jumpBufferCounter -= Time.deltaTime;
        }

        // Checks if space bar was pressed within 0.2 seconds of touching the ground and that it was pressed within 0.2 seconds of the player being grounded.
        if ((coyoteTimeCounter > 0f && jumpBufferCounter > 0f) || hitEnemy)
        {
            animator.SetTrigger("Jump");

            // Checks if bounced on enemy or not.
            if (hitEnemy)
            {
                // Sets animation for jump and sets jump for to double when bouncing on enemy.
                playerVelocity.y = 2f * jumpForce;
                hitEnemy = false;
            }
            else
            {
                // Sets jump force for jump and animation.
                playerVelocity.y = jumpForce;
                doubleJump = true;
            }

            // Resets coyoteTimeCounter and jumpBufferCounter.
            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;
            jumpButton = false;
        }

        // Checks if the player is on the ground.
        if (controller.isGrounded)
        {
            if (playerVelocity.y < 0)
            {
                animator.ResetTrigger("Jump");
                animator.ResetTrigger("WallGrab");
                animator.ResetTrigger("DoubleJump");
                animator.speed = 1.2f;
                
                playerVelocity.y = -0.5f;

                // Resets jumping variables.
                jumpTimer = 0;
                wallJump = false;
                isJumping = false;
                isWallJumping = false;
            }

            // Sets coyoteTimerCounter to 0.2 (amount of leeway time the user has to press the jump button after being grounded).
            coyoteTimeCounter = coyoteTime;
        }
        else if (!controller.isGrounded)
        {
            animator.ResetTrigger("Idle");

            // Checks if space was pressed.
            if (jumpButton)
            {
                // Checks if player is on a wall and performs a wall jump.
                if (wallJump)
                {
                    // Sets the jump animation. 
                    animator.SetTrigger("Jump");
                    animator.ResetTrigger("WallGrab");
                    animator.ResetTrigger("DoubleJump");
                    animator.speed = 1.2f;

                    // Sets jump force and x direction based on the direction of the wall.
                    playerVelocity = wallNormalDirection * velocity;
                    playerVelocity.y = jumpForce;

                    // Sets the angle of the player.
                    transform.eulerAngles = new Vector3(0f, wallNormalDirection.x * 90, 0f);

                    // Disables wall jump and enables double jump.
                    wallJump = false;
                    doubleJump = true;
                    isWallJumping = true;
                }
                // Checks if double jump can be done.
                else if (doubleJump)
                {
                    animator.SetTrigger("DoubleJump");

                    // Player performs jump and disables double jump capability.
                    playerVelocity.y = jumpForce;
                    doubleJump = false;
                    isWallJumping = false;
                }

                jumpButton = false;
            }

            // Decrements coyoteTimeCounter.
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Creates delay for jumping (user able to press direction of player sligthly after space bar is pressed.).
        if (jumpTimer >= 50)
        {
            isJumping = true;
        }

        jumpTimer++;
    }

    /* Collision events. */
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Checks if player is not on ground and hits a wall.
        if (!controller.isGrounded && hit.gameObject.tag == "Wall")
        {
            // Gets the normal direction of the wall and sets wall jump to true.
            wallNormalDirection = hit.normal;
            wallJump = true;

            if (wallNormalDirection.x > 0)
            {
                wallNormalDirection.x = 1;
            }
            else
            {
                wallNormalDirection.x = -1;
            }

            // Sets the direction of the player to the opposite of the wall's normal direction.
            transform.eulerAngles = new Vector3(0f, wallNormalDirection.x * -90, 0f);

            // Resets the jump/ idle animations and enables wall grab animation.
            animator.ResetTrigger("Jump");
            animator.ResetTrigger("Idle");
            animator.SetTrigger("WallGrab");
            animator.speed = 2f;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        movePlayer();
        jump();

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
