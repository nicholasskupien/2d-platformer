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

    public float rayLength;

    public LayerMask groundLayer;

    public Transform leftPoint;

    public Transform rightPoint;

    private bool grounded = true;

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
        CheckStatus();
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
            if (grounded)
            {
                rb.velocity = new Vector2(gI.valueX * speed, jumpForce);
            }
        }
        gI.jumpInput = false;
    }

    private void CheckStatus()
    {
        RaycastHit2D leftCheckHit =
            Physics2D
                .Raycast(leftPoint.position,
                Vector2.down,
                rayLength,
                groundLayer);

        RaycastHit2D rightCheckHit =
            Physics2D
                .Raycast(rightPoint.position,
                Vector2.down,
                rayLength,
                groundLayer);

        if (leftCheckHit || rightCheckHit)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        SeeRays (leftCheckHit, leftPoint);
        SeeRays (rightCheckHit, rightPoint);
    }

    public void SeeRays(RaycastHit2D leftCheckHit, Transform point)
    {
        Color color1 = leftCheckHit ? Color.red : Color.green;
        Debug.DrawRay(point.position, Vector2.down * rayLength, color1);
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
