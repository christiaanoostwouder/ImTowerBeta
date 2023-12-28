using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movespeed = 2.5f;

    public float groundDrag;

    public float jumpForce;
    public float jumpCoolDown = 1f;
    public float airMultiplier;
    public bool readyToJump = true;

    
    
    

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public Rigidbody rb;

    private void start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

       
       
    }

    private void FixedUpdate()
    {
        Moveplayer();
    }

    private void Update()
    {
        if(groundDrag != 50f)
        {
            movespeed = 0f;
        }

        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if(grounded && jumpCoolDown > 6f)
        {
            readyToJump = true;
        }

        

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movespeed = 4.5f;
        }
        else
        {
            movespeed = 2.5f;
        }


        //when to jump
        if(Input.GetKeyDown(jumpKey) && readyToJump)
        {                       
            Jump();           
        }
    }

    private void Moveplayer()
    {
        //movement direction calculation
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        //on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * movespeed * 5f, ForceMode.Force);

        //in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * movespeed * 5f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > movespeed)
        {
            Vector3 limitedVel = flatVel.normalized * movespeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        readyToJump = false;
        Invoke(nameof(ResetJump), jumpCoolDown);
    }
    

    void ResetJump()
    {
        readyToJump = true;
    }
}
