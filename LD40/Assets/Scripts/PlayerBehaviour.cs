using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float PlayerMaxSpeed { get; set; }
    public float PlayerSpeed { get; set; }
    private bool _IsDead = false;

    // Use this for initialization
    void Start () {
        PlayerSpeed = 100;
        PlayerMaxSpeed = 10;
	}

    void Kill()
    {
        _IsDead = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
