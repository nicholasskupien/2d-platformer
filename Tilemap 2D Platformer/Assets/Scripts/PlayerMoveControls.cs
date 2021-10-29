using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed;

    public float jumpForce;

    private GatherInput gI;

    private Rigidbody2D rb;

    private Animator anim;

    private int direction = 1;

    private void Start()
    {
        gI = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        SetAnimatorValues();
    }

    private void FixedUpdate()
    {
        Move();
        JumpPlayer();
    }

    private void Move()
    {
        Flip();
        rb.velocity = new Vector2(speed * gI.valueX, rb.velocity.y);
    }

    private void JumpPlayer()
    {
        if (gI.jumpInput)
        {
            rb.velocity = new Vector2(gI.valueX * speed, jumpForce);
        }
        gI.jumpInput = false;
    }

    private void Flip()
    {
        if (gI.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }

    private void SetAnimatorValues()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}
