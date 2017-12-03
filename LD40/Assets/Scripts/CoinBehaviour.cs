using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    private int __value;

	// Use this for initialization
	void Start () {
        __value = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    // Tries to get grabbed by the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        CoinGrabber coinGrabber = other.gameObject.GetComponent<CoinGrabber>();
        if (null==coinGrabber)
            return;

        coinGrabber.addCoin(__value);
        Destroy(this.gameObject);
    }
}
