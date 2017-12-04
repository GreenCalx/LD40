using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    public int __value;
    public List<GameObject> SpawnWhenGrabbed;

    public AudioClip OnGrab;
    public AudioClip OnSpawnObject;

    // Use this for initialization
    void Start () {
        __value = 1;
        foreach(GameObject go in SpawnWhenGrabbed)
        {
            go.SetActive(false);
        }
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

        AudioSource.PlayClipAtPoint(OnGrab, transform.position);

        foreach ( GameObject go in SpawnWhenGrabbed)
        {
            go.SetActive(true);
            AudioSource.PlayClipAtPoint(OnSpawnObject, go.transform.position);
        }

        Destroy(this.gameObject);
    }
}
