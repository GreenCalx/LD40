﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEntity : ColoredEntity {

    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override bool checkColor()
    {
        return (cvs.getColor() != ColorVisionHandler.COLOR.YELLOW);
    }
}
