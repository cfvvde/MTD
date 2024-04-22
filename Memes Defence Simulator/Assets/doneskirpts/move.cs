using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 15f;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpPower;
    private CharacterController charc;
    private Vector3 walkDir;
    private Vector3 velocity;


    private void Start()
    {
        charc = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Jump(Input.GetKey(KeyCode.Space) && charc.isGrounded);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        walkDir = transform.right * x + transform.forward * z;
    }
    private void FixedUpdate()
    {
        Walk(walkDir);
        DoGravity(charc.isGrounded);
        if (transform.position.y < -100)
        {
            
        }
    }
    private void Walk(Vector3 direction)
    {
        charc.Move(direction * movementSpeed * Time.fixedDeltaTime);
    }
    private void DoGravity(bool isGrounded)
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        velocity.y -= gravity * Time.fixedDeltaTime * 2;
        charc.Move(velocity * Time.fixedDeltaTime);

    }
    private void Jump(bool canJump)
    {
        if (canJump)
        {
            velocity.y = jumpPower;
        }


    }
}
