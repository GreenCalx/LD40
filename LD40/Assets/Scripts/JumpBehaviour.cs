using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour {

    public bool IsJumping { get; set; }
    public float JumpPower { get; set; }

	// Use this for initialization
	void Start () {
        IsJumping = false;
        JumpPower = 10;
	}

    private void OnTriggerStay(Collider other)
    {
        if (IsJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * JumpPower);
        }
    }
    // Update is called once per frame
    void Update () {

	}
}
