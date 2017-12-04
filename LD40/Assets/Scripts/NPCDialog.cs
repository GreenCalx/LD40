using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour {

    private string __greetings = "Hello !";
    // Use this for initialization
    void Start () {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DisplayMenu m = GetComponentInChildren<DisplayMenu>();
        if(m) m.ToggleDisplay();
    }

    // Update is called once per frame
    void Update () {  

	}
}
