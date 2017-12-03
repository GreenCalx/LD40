using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {

    public string sceneNameDestination;

    private string __activeSceneName;

	// Use this for initialization
	void Start () {
        __activeSceneName = SceneManager.GetActiveScene().name;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneNameDestination);
    }


}
