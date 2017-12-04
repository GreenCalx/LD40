using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDependentPosition : MonoBehaviour {
    public int WidthPercent = 0;
    public int HeightPercent = 0;

    private Vector2 ScreenSize;
    RectTransform rt;

	// Use this for initialization
	void Start () {
        rt = GetComponent<RectTransform>();
        ScreenSize = new Vector2(Screen.width, Screen.height);
        rt.position = new Vector3((ScreenSize.x* (WidthPercent/100f)), (ScreenSize.y * (HeightPercent / 100f)), 0);
    }
	
	// Update is called once per frame
	void Update () {
        if ( Screen.width != ScreenSize.x || Screen.height != ScreenSize.y )
            rt.position = new Vector3(WidthPercent, HeightPercent, 0);
    }
}
