using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorVisionSelector : MonoBehaviour {

    private int n_available_filters;
    private List<ColorVisionHandler.COLOR>  __activeColor;
    private ColorVisionHandler              __colorVisionHandler;

	// Use this for initialization
	void Start () {

        // Poll UPGRADES
        Upgrades upgrades = GameObject.Find("player").GetComponent<Upgrades>();
        if (null!=upgrades)
            n_available_filters = upgrades.n_filters;
        else
            n_available_filters = 1;

        // Set Fixed size for active colors
        __activeColor = new List<ColorVisionHandler.COLOR>(n_available_filters);

        for ( int i=0; i< n_available_filters;++i)
            __activeColor.Add(ColorVisionHandler.COLOR.NEUTRAL);

        __colorVisionHandler = new ColorVisionHandler();

    }
	
	// Update is called once per frame
	void Update () {

        bool blueFilter     = Input.GetKeyDown(KeyCode.B);
        bool redFilter      = Input.GetKeyDown(KeyCode.R);
        bool yellowFilter   = Input.GetKeyDown(KeyCode.Y);
        bool neutralFilter  = Input.GetKeyDown(KeyCode.N);

        if ( blueFilter && (!__activeColor.Contains(ColorVisionHandler.COLOR.BLUE)) )
        {
            insertColor(ColorVisionHandler.COLOR.BLUE);
        }

        if (redFilter && (!__activeColor.Contains(ColorVisionHandler.COLOR.RED)))
        {
            insertColor(ColorVisionHandler.COLOR.RED);
        }   

        if (yellowFilter && (!__activeColor.Contains(ColorVisionHandler.COLOR.YELLOW)))
        {
            insertColor(ColorVisionHandler.COLOR.YELLOW);
        }

        if (neutralFilter)
        {
            insertColor(ColorVisionHandler.COLOR.NEUTRAL);
        }

        Debug.Log("Active Color : " + getColor().ToString());
    }


    public void insertColor(ColorVisionHandler.COLOR iColor)
    {
        if (__activeColor.Count == 2)
        {
            __activeColor[0] = __activeColor[1];
            __activeColor[1] = iColor;
        }
        else if ( __activeColor.Count == 1 )
        {
            __activeColor[0] = iColor;
        }


        Debug.Log("Active Colors : " + __activeColor[0] + " , " + __activeColor[1]);
    }

    public List<ColorVisionHandler.COLOR> getActiveColors() { return __activeColor; }
    public void setActiveColors( List<ColorVisionHandler.COLOR> iColors) { __activeColor = iColors; }


    public ColorVisionHandler.COLOR getColor()
    {
        if ( n_available_filters == 1 )
            return __activeColor[0];
        else if ( n_available_filters == 2 )
            return __colorVisionHandler.getCombinedColor(__activeColor);
        else
            return ColorVisionHandler.COLOR.NEUTRAL;
    }

}
