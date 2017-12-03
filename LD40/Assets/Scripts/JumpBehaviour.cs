using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour {

    public bool IsJumping { get; set; }
    public bool HasDoubleJumped { get; set; }

    public float JumpPower { get; set; }
    public bool AskedForJump { get; set; }
    public bool WallSlide { get; set; }

    Rigidbody2D rb;
    public Vector3 SurfaceNormal;

    // Use this for initialization
    void Start () {
        IsJumping = false;
        AskedForJump = false;
        JumpPower = 15;
        HasDoubleJumped = false;
        rb = GetComponent<Rigidbody2D>();
    }

    public void AskForJump()
    {
        AskedForJump = false;
        if (!IsJumping)
        {
            AskedForJump = true;
        }

        if (IsJumping && !HasDoubleJumped)
        {
            AskedForJump = true;
            HasDoubleJumped = true;
        }

        if (WallSlide)
        {
            AskedForJump = true;
        }
        Debug.Log("AskedForJump : " + AskedForJump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter");
        IsJumping = false;
        HasDoubleJumped = false;
        SurfaceNormal = collision.contacts[0].normal;
        if (Vector2.Dot(SurfaceNormal, Vector2.up) <= 0.1)
        { 
            // WAll riding
            WallSlide = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("CollisionExit");
        IsJumping = true;
        WallSlide = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        IsJumping = false;
        HasDoubleJumped = false;
        SurfaceNormal = collision.contacts[0].normal;
        if (Vector2.Dot(SurfaceNormal, Vector2.up) <= 0.1)
        {
            // WAll riding
            WallSlide = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        Debug.Log(WallSlide + " " + IsJumping + " " + HasDoubleJumped);
        if(AskedForJump)
        {
            if (WallSlide)
            {
                rb.AddForce(new Vector2(SurfaceNormal.x*100, SurfaceNormal.y), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(0, SurfaceNormal.y * JumpPower), ForceMode2D.Impulse);
            }
            AskedForJump = false;
            return;
        }

        if (WallSlide)
        {
            rb.velocity = new Vector2(0, -0.7f);
        }
    }
}
