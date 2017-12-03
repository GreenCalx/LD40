using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool _IsMenuMode;
    Rigidbody2D rb;
    JumpBehaviour jump;
    PlayerBehaviour behaviour;

    public static KeyCode AccelarationKey = KeyCode.LeftShift;

    // Use this for initialization
    void Start () {
        _IsMenuMode = false;
         rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<JumpBehaviour>();
        behaviour = GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(AccelarationKey))
        {
            behaviour.PlayerSpeed = behaviour.PlayerMaxSpeed; 
        }
        if (Input.GetKeyUp(AccelarationKey))
        {
            behaviour.PlayerSpeed = PlayerBehaviour.PlayerBaseSpeed;
        }
                return;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float Movement = Input.GetAxis("Horizontal");
        
    }
}
