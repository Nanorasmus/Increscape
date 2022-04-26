using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float brakeSpeed = 2;

    public float baseSpeed = 4;
    public float maxSpeed;
    public float speed;

    public float baseJumpPower = 5;
    public float maxJumpPower;
    public float jumpPower;
    public int jumps = 1;

    private Rigidbody2D rb;

    private int jumpsLeft;

    // Sets jumps to max
    public void SetJumps()
    {
        jumpsLeft = jumps;
    }

    // Sets jumps to specified amount
    public void SetJumps(int toAmount)
    {
        jumpsLeft = toAmount;
    }

    private void Start()
    {
        // Walk System Init
        maxSpeed = baseSpeed;
        speed = baseSpeed;

        // Jump System Init
        maxJumpPower = baseJumpPower;
        jumpPower = baseJumpPower;
        jumpsLeft = jumps;

        // Getting References
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float move = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        bool jump = false;

        if (jumpsLeft > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            jumpsLeft--;
            jump = true;
        }

        rb.velocity = new Vector2(rb.velocity.x + move - rb.velocity.x * Time.deltaTime * brakeSpeed, jump ? jumpPower : rb.velocity.y);
    }
}
