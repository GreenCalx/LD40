using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour {

    private bool IsAlive = true;

	// Use this for initialization
	void Start () {
		
	}

    public void Kill()
    {
        IsAlive = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION ENTER ENNEMYBEHAVIOUR");
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
        if (!IsAlive)
            Destroy(this.gameObject);
	}
}
