﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGrabber : MonoBehaviour {

    private int __coinGrabbed;

	// Use this for initialization
	void Start () {
        __coinGrabbed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void addCoin(int n_coin)
    {
        __coinGrabbed += n_coin;
    }

}
