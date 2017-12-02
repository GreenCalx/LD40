using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    private int _Health;
    private Animator _MainAnimator;
    private PlayerController _Controller;
    // Use this for initialization
	void Start () {
	     	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdatePositionFromInputs()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { 
        }
    }
}
