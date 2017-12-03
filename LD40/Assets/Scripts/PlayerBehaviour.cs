using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    public float PlayerMaxSpeed { get; set; }
    public float PlayerSpeed { get; set; }
    private bool _IsDead = false;

    // Use this for initialization
    void Start () {
        PlayerSpeed = 100;
        PlayerMaxSpeed = 10;
	}

    public void Kill()
    {
        _IsDead = true;
        SceneManager.LoadScene("game_over");
    }
	
	// Update is called once per frame
	void Update () {
        if (_IsDead)
            Destroy(this.gameObject);
		
	}
}
