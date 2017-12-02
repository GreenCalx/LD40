using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private static Vector3 _DirectionRight = new Vector3( 1, 0, 0);
    private static Vector3 _DirectionLeft  = new Vector3(-1, 0, 0);
    private static Vector3 _DirectionUp    = new Vector3( 0, 1, 0);
    private static Vector3 _DirectionDown  = new Vector3( 0,-1, 0);

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
            if(Input.GetKey(KeyCode.RightArrow)) {    
                transform.Translate(_DirectionRight * behavior._PlayerSpeed);
                
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(_DirectionLeft * behavior._PlayerSpeed);
            }


            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(_DirectionUp * behavior._PlayerSpeed);
            }


            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(_DirectionDown * behavior._PlayerSpeed);
            }
        }
	}
}
