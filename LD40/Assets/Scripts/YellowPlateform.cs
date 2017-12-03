using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlateform : BasePlateform {

    void Start()
    {
        base.Start();
    }

    public override bool checkColor()
    {
        return ( cvs.getColor() != ColorVisionHandler.COLOR.YELLOW );
    }
}
