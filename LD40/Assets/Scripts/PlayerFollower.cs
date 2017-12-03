using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour {

    float SmoothSpeed = 0.125f;
    Transform target;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("player").transform;
	}

	// Update is called once per frame
	void LateUpdate () {
        Vector3 DesiredPosition = target.position;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);
        transform.position = new Vector3(SmoothedPosition.x, SmoothedPosition.y, transform.position.z);
        
	}
}
