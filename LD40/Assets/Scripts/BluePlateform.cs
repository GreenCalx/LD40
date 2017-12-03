using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlateform : BasePlateform {

    void Start()
    {
        base.Start();
    }

    public override bool checkColor()
    {
        return ( cvs.getColor() != ColorVisionHandler.COLOR.BLUE );
    }

}
