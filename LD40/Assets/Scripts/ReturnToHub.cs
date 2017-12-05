using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToHub : MonoBehaviour {

    private int WaitingTime = 5;
    private float TimeAccumulation = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeAccumulation += Time.deltaTime;

        if( (TimeAccumulation > WaitingTime) || (Input.anyKeyDown) )
        {
            SceneManager.LoadScene("scene_hub");
        }
	}
}
