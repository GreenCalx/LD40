using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool _IsMenuMode;
    Rigidbody2D rb;
    JumpBehaviour jump;
    PlayerBehaviour behaviour;

    KeyCode JumpKey = KeyCode.UpArrow;

    // Use this for initialization
    void Start () {
        _IsMenuMode = false;
         rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<JumpBehaviour>();
        behaviour = GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            jump.AskForJump();
        }
        return;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float Movement = Input.GetAxis("Horizontal");
        /*   if (jump.WallSlide)
           {
               Vector2 MovementVector = new Vector2(Movement * behaviour._PlayerSpeed, rb.velocity.y);
               if (Vector2.Dot(jump.SurfaceNormal, MovementVector) > 0) {
                   Debug.Log("hello");
                   rb.velocity = new Vector2(Movement * behaviour._PlayerSpeed, rb.velocity.y);
               }
           }
           else */
        /*     {

                 if (!jump.WallSlide)
                 {
                     if (Movement * rb.velocity.x < behaviour.PlayerMaxSpeed)
                         rb.AddForce(Vector2.right * Movement * behaviour.PlayerSpeed);

                     if (Mathf.Abs(rb.velocity.x) > behaviour.PlayerMaxSpeed)
                         rb.velocity = new Vector2(Mathf.Sign(Movement) * behaviour.PlayerMaxSpeed, rb.velocity.y);

                     if (Movement == 0)
                         rb.AddForce(-rb.velocity);
                 }
                 else
                 {
                     rb.velocity = new Vector2(0, 0);
                 }
                 //Debug.Log(Movement);
                 //Debug.Log(rb.velocity.x);

             }
             */
             if(!jump.WallSlide)
                 rb.velocity = new Vector2(Movement * behaviour.PlayerMaxSpeed, rb.velocity.y);
    }
}
