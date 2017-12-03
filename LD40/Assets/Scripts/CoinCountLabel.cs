using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCountLabel : MonoBehaviour {

    private CoinGrabber __coinGrabber;
    private GameObject __player;
    private Text __text;

    // Use this for initialization
    void Start () {
        __player = GameObject.Find("player");
        __coinGrabber = __player.GetComponent<CoinGrabber>();
        __text = GetComponent<Text>();

    }

    void onGUI()
    {
        __text.text = "COINS : " + __coinGrabber.getCoins().ToString();
    }
	
	// Update is called once per frame
	void Update () {
        __text.text = "COINS : " + __coinGrabber.getCoins().ToString();
    }
}
