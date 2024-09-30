using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Variables for player movement
    public float Speed;
    public float rotationSpeed;
    public float sprintSpeed;
    public float jumpSpeed;
    public float jumpButtonGracePeriod;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    void Start()
    {
        animator = GetComponent<Animator>(); //Will get the Animator component
        characterController = GetComponent<CharacterController>(); //Will get the CharacterController component
        originalStepOffset = characterController.stepOffset;
    }

    void Update()
    {
        //Will move the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        //Will determine if the player is Sprinting
        float currentSpeed = Speed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        //Calculates the movement magnitude
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * currentSpeed;

        //Will make the player Jump
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        if(Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if(Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }



        transform.Translate(movementDirection * Speed * Time.deltaTime, Space.World);

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        //Will rotate the player in the direction of travel and activate animations
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
