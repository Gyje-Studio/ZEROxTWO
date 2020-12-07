using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
    CharacterController characterController;

    public float walkSpeed = 4.0f;
    public float runSpeed = 6.0f;
    public float jumSpeed = 4.0f;
    public float gravity = 20.0f;
    public float x, y;

    private Vector3 move = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        if (characterController.isGrounded)
        {
            move = new Vector3(x, 0.0f, y);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Caminar", true);
            }
            else
            {
                animator.SetBool("Caminar", false);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                move = transform.TransformDirection(move) * runSpeed;
                animator.SetBool("Correr", true);
            }
            else
            {
                move = transform.TransformDirection(move) * walkSpeed;
                animator.SetBool("Correr", false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                move.y = jumSpeed;
            }
            move = transform.TransformDirection(move) * walkSpeed;
        }
        move.y -= gravity * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);
        
    }
}
