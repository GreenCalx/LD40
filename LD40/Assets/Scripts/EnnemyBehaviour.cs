using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour {

    private bool IsAlive = true;

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.collider.gameObject;
        if (go.name.Contains("player"))
        {
            PlayerBehaviour p = go.GetComponent<PlayerBehaviour>();
            if (p)
            {
                p.Kill();
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
