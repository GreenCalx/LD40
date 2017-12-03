using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorVisionHandler  {

    public enum COLOR {NEUTRAL, RED, BLUE, YELLOW , PURPLE , ORANGE , GREEN };
    public enum ADVANCED_COLOR { PURPLE, ORANGE, GREEN };

    public  Dictionary< List<COLOR>, COLOR> __colorMap;

	// Use this for initialization
	public ColorVisionHandler() {

        // Build Color Table
        __colorMap = new Dictionary<List<COLOR>, COLOR>();

        List<COLOR> purple = new List<COLOR>();
        purple.Add(COLOR.BLUE); purple.Add(COLOR.RED);
        __colorMap.Add( purple, COLOR.PURPLE );
        purple = new List<COLOR>();
        purple.Add(COLOR.RED); purple.Add(COLOR.BLUE);
        __colorMap.Add(purple, COLOR.PURPLE);

        List<COLOR> orange = new List<COLOR>();
        orange.Add(COLOR.YELLOW); orange.Add(COLOR.RED);
        __colorMap.Add(orange, COLOR.ORANGE);
        orange = new List<COLOR>();
        orange.Add(COLOR.RED); orange.Add(COLOR.YELLOW);
        __colorMap.Add(orange, COLOR.ORANGE);

        List<COLOR> green = new List<COLOR>();
        green.Add(COLOR.BLUE); green.Add(COLOR.YELLOW);
        __colorMap.Add(green, COLOR.GREEN);

        green = new List<COLOR>();
        green.Add(COLOR.YELLOW); green.Add(COLOR.BLUE);
        __colorMap.Add(green, COLOR.GREEN);


        // Build Color Table

    }


    public COLOR getCombinedColor(List<COLOR> iColors)
    {
        if ( iColors.Count < 2 )
            return COLOR.NEUTRAL;

        if ( iColors.Contains(COLOR.NEUTRAL) )
        {
            int i_neutral = iColors.IndexOf(COLOR.NEUTRAL);
            return iColors[1-i_neutral];
        }

        COLOR retCol = COLOR.NEUTRAL;
        if (iColors.Contains(COLOR.RED) && iColors.Contains(COLOR.BLUE))
            retCol = COLOR.PURPLE;
        else if (iColors.Contains(COLOR.YELLOW) && iColors.Contains(COLOR.BLUE))
            retCol = COLOR.GREEN;
        else if (iColors.Contains(COLOR.RED) && iColors.Contains(COLOR.YELLOW))
            retCol = COLOR.ORANGE;

        return retCol;
        //return __colorMap[iColors];
    }

}
