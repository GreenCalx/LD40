using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public float speedFactor;

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
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = simulateMove();
        //__gameObjectTransform.Translate( simulateMove() );
    }

    public Vector3 simulateMove()
    {
        return new Vector3( __currentDirection.x * speedFactor,
                            __currentDirection.y * speedFactor
                          );
    }

    // NOT WORKING AS INTENDED !!!!!!!
    public void moveToPoint(Vector3 iPointInWorldCoordinates)
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = __gameObjectTransform.position - iPointInWorldCoordinates;
    }


    public Vector3 getSimulatedMoveInWorldPosition()
    {
        return __gameObjectTransform.position + simulateMove();
    }



    // MUTATORS
    public Vector2 getCurrentDirection() { return __currentDirection; }
    public void setCurrentDirection(Vector2 iCurrentDirection) { __currentDirection = iCurrentDirection; }

    public Transform getObjectTransform() { return __gameObjectTransform; }

    public float getSpeedFactor() { return speedFactor; }
    public void setSpeedFactor(float iSpeedFactor) { speedFactor = iSpeedFactor; }
}

