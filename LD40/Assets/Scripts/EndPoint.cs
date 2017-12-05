using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour {

    private bool IsEnabled = false;
    private int WaitingTime = 1;
    private float TimeAccumulation = 0;
    private CoinGrabber cg = null;
    private TextMesh tm = null;
    private GameObject player;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("player");
        if(player)
        {
           cg = player.GetComponent<CoinGrabber>();
        }

        tm = GetComponentInChildren<TextMesh>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TimeAccumulation = 0;
        if(!IsEnabled)
        {
            if(tm)
            {
                tm.text = "NO COIN";
            }
        }
        else
        {
            if (tm) tm.text = "GG !!!!";
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        TimeAccumulation = 0;
        if(!IsEnabled)
        {
            if (tm) tm.text = "EXIT";
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (IsEnabled)
        {
            TimeAccumulation += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update () {
        if ( TimeAccumulation > WaitingTime )
        {
            Upgrades.CurrentScore = cg.getCoins();
            Upgrades.CurrentHighScore = (Upgrades.CurrentHighScore < Upgrades.CurrentScore) ? Upgrades.CurrentScore : Upgrades.CurrentHighScore;

            SceneManager.LoadScene("scene_hub");
        }

        if (cg)
        {
            if (cg.getCoins() > 0)
            {
                IsEnabled = true;
            }
        }
    }
}
