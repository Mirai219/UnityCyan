using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    Rigidbody rb;
    PlayerGroundDetector groundDetector;

    public float MoveSpeed => Mathf.Abs(rb.velocity.x);
    public bool IsGrounded => groundDetector.IsGrounded;
    public bool IsFalling => rb.velocity.y < 0 && !IsGrounded;

    public bool CanAirJump { get; set; } = false;
    private void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        input.EnableGamePlayInputs();
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector3(velocityX, rb.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector3(rb.velocity.x,velocityY);
    }

    public void Move(float speed)
    {
        SetVelocityX(speed * input.AxisX);
        if(input.Move)
        {
            FlipAccordingToMove();
        }
    }
    
    public void FlipAccordingToMove()
    {
        transform.localScale = new Vector3(input.AxisX, 1f, 1f);
    }
    
    public void EnableGravity()
    {
        rb.useGravity = true;
    }

    public void DiasbleGravity()
    {
        rb.useGravity = false;
    }
}
