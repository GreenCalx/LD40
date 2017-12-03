using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredEntity : MonoBehaviour {

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
        if (!activate)
            sr.color = new Color(1f, 1f, 1f, .2f);
        else
            sr.color = new Color(1f, 1f, 1f, 1f);

        BoxCollider2D[] b2D = GetComponents<BoxCollider2D>();
        foreach (var collider in b2D)
            collider.enabled = activate;
    }

}
