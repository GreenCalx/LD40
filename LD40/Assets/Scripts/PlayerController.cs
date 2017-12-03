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
            //jump.AskForJump();
        }
        return;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float Movement = Input.GetAxis("Horizontal");
        
    }
}
