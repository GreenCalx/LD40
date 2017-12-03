using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableByBloc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("TRIGGER ENTER KILLABLEBYBLOC");
        GameObject go = collider.gameObject;
        if (go)
        {
            if (go.GetComponent<BasePlateform>())
            {
                ;
                EnnemyBehaviour behaviour = GetComponent<EnnemyBehaviour>();
                if (behaviour)
                {
                    behaviour.Kill();
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
