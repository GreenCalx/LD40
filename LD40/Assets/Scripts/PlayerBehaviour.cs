using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    public static int PlayerBaseSpeed = 15;
    public static int PlayerBaseMaxSpeed = 25;

    public float PlayerMaxSpeed { get; set; }
    public float PlayerSpeed { get; set; }
    private bool _IsDead = false;

    public AudioClip DeathSound;

    // Use this for initialization
    void Start () {
        PlayerSpeed = PlayerBaseSpeed;
        PlayerMaxSpeed = PlayerBaseMaxSpeed;
	}

    public void Kill()
    {
        _IsDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsDead)
        {
            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            Destroy(this.gameObject);           
            SceneManager.LoadScene("game_over");
        }
    }
}
