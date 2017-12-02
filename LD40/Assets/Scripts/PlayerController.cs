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
	void Update () {
        Transform transform = GetComponent<Transform>();
        PlayerBehaviour behavior = GetComponent<PlayerBehaviour>();
        if(transform) {
            if(Input.GetAxis("Horizontal") > 0) {    
                transform.Translate( Vector3.right * behavior._PlayerSpeed);               
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate( -Vector3.right * behavior._PlayerSpeed);
            }


            if (Input.GetAxis("Vertical") > 0)
            {
                JumpBehaviour jump = GetComponent<JumpBehaviour>();
                jump.IsJumping = true;
                //transform.Translate(_DirectionUp * behavior._PlayerSpeed);
            }


            if (Input.GetAxis("Vertical") < 0)
            {
                //transform.Translate(_DirectionDown * behavior._PlayerSpeed);
            }
        }
	}
}
