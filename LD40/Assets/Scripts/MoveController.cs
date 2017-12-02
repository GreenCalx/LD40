using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public int speedFactor { get; set; }

    private Transform   __gameObjectTransform;
    private Vector2     __currentDirection;


	// Use this for initialization
	void Start () {
        __gameObjectTransform = this.gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // MOVE METHODS
    public void move()
    {
        __gameObjectTransform.Translate( new Vector3(   __currentDirection.x * speedFactor, 
                                                        __currentDirection.y * speedFactor
                                                    ));
    }

    // MUTATORS
    public Vector2 getCurrentDirection() { return __currentDirection; }
    public void setCurrentDirection(Vector2 iCurrentDirection) { __currentDirection = iCurrentDirection; }

    public Transform getObjectTransform() { return __gameObjectTransform; }
}

