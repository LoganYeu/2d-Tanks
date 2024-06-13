using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // starting rotation
        Quaternion startingRotation = Quaternion.Euler(0, 0, 270);
        rb.MoveRotation(startingRotation);
    }

    private void FixedUpdate()
    {
        // Movement
        setPlayerVelocity();
        rotateTowardInputDirection();
    }

    private void setPlayerVelocity()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        // Movement
        rb.velocity = movement * moveSpeed;
    }

    private void rotateTowardInputDirection()
    {
        if (movement != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, movement);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            rb.MoveRotation(rotation);
        }
    }
}
