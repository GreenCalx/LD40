using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour {

    public bool IsJumping { get; set; }

    public float JumpPower { get; set; }
    public bool AskForJump { get; set; }
	// Use this for initialization
	void Start () {
        IsJumping = false;
        AskForJump = false;
        JumpPower = 800;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsJumping = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        IsJumping = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsJumping = true;
    }

    // Update is called once per frame
    void FixedUpdate () {
        Debug.Log(AskForJump);
        if(AskForJump)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0,JumpPower));
            AskForJump = false;
        }

    }
}
