using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableByWeakPoint : KillableByBloc {

    public Collider2D WeakSpot;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("TRIGGER ENTER KILLABLEBYBLOC");
        GameObject go = collider.gameObject;
        if (go)
        {
            if (go.GetComponent<BasePlateform>())
            {
                EnnemyBehaviour behaviour = GetComponent<EnnemyBehaviour>();
                if (behaviour &&  WeakSpot.IsTouching(collider) )
                {
                    behaviour.Kill();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
