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
    void onTriggerEnter(Collider collider)
    {
        CoinGrabber coinGrabber = collider.GetComponentInParent<CoinGrabber>();
        if (!!coinGrabber)
            return;

        coinGrabber.addCoin(__value);
        Destroy(this);
    }
}
