using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenu : MonoBehaviour {
    // Use this for initialization
    void Start () {
        ToggleDisplay();
	}

    public void ToggleDisplay()
    {
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
