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
    Vector3 SurfaceNormal;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsJumping = false;
        HasDoubleJumped = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        IsJumping = false;
        HasDoubleJumped = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsJumping = true;
        WallSlide = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SurfaceNormal = collision.contacts[0].normal;
        Debug.Log(Vector2.Dot(SurfaceNormal, Vector2.up));
        if (Vector2.Dot(SurfaceNormal, Vector2.up) <= 0.1)
        { 
            // WAll riding
            WallSlide = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(AskedForJump)
        {
            if (WallSlide)
            {
                rb.AddForce(new Vector2(SurfaceNormal.x * JumpPower*2, JumpPower), ForceMode2D.Impulse);
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
            Debug.Log("wallslide");
            rb.velocity = new Vector2(0, -0.7f);
        }
    }
}
