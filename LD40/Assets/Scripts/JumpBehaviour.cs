using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour {

    public bool IsJumping { get; set; }
    public bool HasDoubleJumped { get; set; }

    public float JumpPower { get; set; }
    public bool AskedForJump { get; set; }

    Rigidbody2D rb; 

    // Use this for initialization
    void Start () {
        IsJumping = false;
        AskedForJump = false;
        JumpPower = 800;
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
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(AskedForJump)
        {         
            rb.AddForce(new Vector2(0,JumpPower));
            AskedForJump = false;
        }
    }
}
