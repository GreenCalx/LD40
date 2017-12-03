using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool _IsMenuMode;

	// Use this for initialization
	void Start () {
        _IsMenuMode = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Transform transform = GetComponent<Transform>();
        PlayerBehaviour behavior = GetComponent<PlayerBehaviour>();
        if(transform) {
            float Movement = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(Movement * behavior._PlayerSpeed, rb.velocity.y);              

            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                JumpBehaviour jump = GetComponent<JumpBehaviour>();
                if(!jump.IsJumping)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jump.JumpPower);
                }
                
                //transform.Translate(_DirectionUp * behavior._PlayerSpeed);
            }

        }
	}
}
