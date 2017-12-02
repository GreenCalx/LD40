using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private static Vector3 DirectionRight = new Vector3( 1, 0, 0);
    private static Vector3 DirectionLeft  = new Vector3(-1, 0, 0);
    private static Vector3 DirectionUp    = new Vector3( 0, 1, 0);
    private static Vector3 DirectionDown  = new Vector3( 0,-1, 0);

    private bool _IsMenuMode;

	// Use this for initialization
	void Start () {
        _IsMenuMode = false;
	}
	
	// Update is called once per frame
	void Update () {
        Transform transform = GetComponent<Transform>();
        if(transform) {
            
            if(Input.GetKeyDown(KeyCode.RightArrow)) {    
                transform.Translate(DirectionRight);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Translate(DirectionLeft);
            }


            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Translate(DirectionUp);
            }


            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Translate(DirectionDown);
            }
        }
	}
}
