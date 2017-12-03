using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour {

    // Jump Logic
    public bool CanDoubleJump { get; set; }
    public bool AskedForJump { get; set; }

    // Physics Data
    Rigidbody2D RB2D;
    //   Collision ray options
    float RayOffsetX;
    float RayOffsetY;
    float RayLength;

    // Jump parameters
    public float speed = 14f;
    public float accel = 6f;
    public float airAccel = 3f;
    public float jump = 14f;
    private Vector2 input;

    // Use this for initialization
    void Start () {
        AskedForJump = false;
        CanDoubleJump = true;
        RB2D = GetComponent<Rigidbody2D>();
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();

        RayOffsetX = collider2D.bounds.extents.x + 0.1f;
        RayOffsetY = collider2D.bounds.extents.y + 0.1f;
        RayLength = 0.01f;
    }

    public bool IsOnWall()
    {
        bool HitLeft  = Physics2D.Raycast(
            new Vector2(transform.position.x - RayOffsetX, transform.position.y), 
                -Vector2.right, RayOffsetY);
        bool HitRight = Physics2D.Raycast(
            new Vector2(transform.position.x + RayOffsetX, transform.position.y), 
                Vector2.right, RayOffsetY);

        return (HitLeft || HitRight);
    }

    public bool IsGrounded()
    {
        bool RayDown1 = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - RayOffsetY), 
               -Vector2.up, RayLength);
        bool RayDown2 = Physics2D.Raycast(
            new Vector2(transform.position.x + (RayOffsetX - 0.2f), transform.position.y - RayOffsetY), 
               -Vector2.up, RayLength);
        bool RayDown3 = Physics2D.Raycast(
            new Vector2(transform.position.x - (RayOffsetX - 0.2f), transform.position.y - RayOffsetY), 
               -Vector2.up, RayLength);
        return (RayDown1 || RayDown2 || RayDown3);
    }

    //Returns whether or not player is touching wall or ground.
    public bool IsTouchingSomething()
    {
        return (IsGrounded() || IsOnWall());
    }

    //Returns direction of wall.
    public int wallDirection()
    {
        bool left = Physics2D.Raycast(
            new Vector2(transform.position.x - RayOffsetX, transform.position.y), 
               -Vector2.right, RayLength);
        bool right = Physics2D.Raycast(
            new Vector2(transform.position.x + RayOffsetX, transform.position.y), 
            Vector2.right, RayLength);

        if (left)
            return -1;
        else if (right)
            return 1;
        else
            return 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            input.x = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            input.x = 1;
        else
            input.x = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            input.y = 1;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (IsGrounded())
            CanDoubleJump = true;

        Debug.Log(CanDoubleJump);

        RB2D.AddForce(new Vector2(((input.x * speed) - RB2D.velocity.x) * (IsGrounded() ? accel : airAccel), 
                                    0)); 

        RB2D.velocity = new Vector2((input.x == 0 && IsGrounded()) ? 0 : RB2D.velocity.x, 
                                    (input.y == 1 && (IsTouchingSomething() || CanDoubleJump)) ? jump : RB2D.velocity.y);

        if (input.y == 1 && !IsTouchingSomething() && CanDoubleJump) CanDoubleJump = false;

        if (IsOnWall() && !IsGrounded() && input.y == 1)
            RB2D.velocity = new Vector2(-wallDirection() * speed * 0.75f, RB2D.velocity.y);

        Debug.Log(CanDoubleJump);

        input.y = 0;
    }
}
