using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour {

    private bool IsEnabled;
    private CoinGrabber cg;

	// Use this for initialization
	void Start () {

        GameObject player = GameObject.Find("player");
        if(player)
        {
           cg = player.GetComponent<CoinGrabber>();
        }
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(cg)
        {
            if(cg.getCoins() > 0)
            {

            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
