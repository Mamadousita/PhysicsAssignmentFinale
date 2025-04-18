using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float gravityMultiplier = 2.5f;
    private bool controlEnabled = true;

    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isJumping;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
           if (!isGrounded)
            {
                rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
            }
        }
    }

    public void SetControl(bool canMove)
    {
        controlEnabled = canMove;
    }

    void FixedUpdate()
    {
        if (!controlEnabled) return;
       
        float moveZ = Input.GetAxis("Horizontal");
        Vector3 targetVelocity = new Vector3(0f, rb.velocity.y, moveZ * moveSpeed);
        rb.velocity = targetVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
     
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    
}
