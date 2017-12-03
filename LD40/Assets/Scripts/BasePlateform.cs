using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlateform : MonoBehaviour
{

    protected bool isActive;
    protected ColorVisionSelector cvs;

    // Use this for initialization
    public void Start()
    {
        cvs = GameObject.Find("player").GetComponent<ColorVisionSelector>();
    }

    // Update is called once per frame
    void Update()
    {

        isActive = checkColor();
        togglePlateforms(isActive);
    }

    public virtual bool checkColor()
    { return true; }

    private void togglePlateforms(bool activate)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //sr.enabled = activate;
        if (!activate)
            sr.color = new Color(1f, 1f, 1f, .5f);
        else
            sr.color = new Color(1f, 1f, 1f, 1f);

        BoxCollider2D b2D = GetComponent<BoxCollider2D>();
        b2D.enabled = activate;
    }

}
