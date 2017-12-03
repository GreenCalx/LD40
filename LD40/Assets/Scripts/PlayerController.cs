using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool _IsMenuMode;
    Rigidbody2D rb;
    JumpBehaviour jump;
    // Use this for initialization
    void Start () {
        _IsMenuMode = false;
         rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<JumpBehaviour>();
    }

    private void Update()
    {
        if (!jump.IsJumping) {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump.AskForJump = true;
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Transform transform = GetComponent<Transform>();
        PlayerBehaviour behavior = GetComponent<PlayerBehaviour>();
        if(transform) {
            float Movement = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(Movement * behavior._PlayerSpeed, rb.velocity.y);              
        }
	}
}
