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
    public bool canJump = true;

    private Rigidbody2D rb;

    private void Start()
    {
        maxSpeed = baseSpeed;
        speed = baseSpeed;

        maxJumpPower = baseJumpPower;
        jumpPower = baseJumpPower;

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float move = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        bool jump = false;

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            jump = true;
        }

        rb.velocity = new Vector2(rb.velocity.x + move - rb.velocity.x * Time.deltaTime * brakeSpeed, jump ? jumpPower : rb.velocity.y);
    }
}
