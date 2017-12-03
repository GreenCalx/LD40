using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour {

    public bool IsJumping { get; set; }

    public float JumpPower { get; set; }
    private bool StartJump;
	// Use this for initialization
	void Start () {
        IsJumping = false;
        StartJump = false;
        JumpPower = 8;
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

    }
}
