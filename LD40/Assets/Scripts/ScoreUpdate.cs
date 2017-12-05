using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour {

    private string InitialString  = "Last Score : ";
    private string InitialString2 = "High Score : ";
    private TextMesh tm;

	// Use this for initialization
	void Start () {
        tm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        tm.text = InitialString + Upgrades.CurrentScore.ToString() + "\n"
                + InitialString2 + Upgrades.CurrentHighScore.ToString();
	}
}
