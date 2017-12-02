﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeRoamAI : MonoBehaviour
{
    public BasePlateform attachedPlateform;

    private MoveController __moveController;

    private Vector2 __currentDirection;
    private Vector2 __leftLimit;
    private Vector2 __rightLimit;
    private bool isMovingLeft;

    public PlateformeRoamAI(BasePlateform iAttachedPlateform)
    {
        attachedPlateform = iAttachedPlateform;
    }

    // Use this for initialization
    void Start()
    {
        Transform plateformTransform = attachedPlateform.GetComponent<Transform>();
        if (!!plateformTransform)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            float width = sr.sprite.bounds.size.x;
            float scaledWidth = (width * plateformTransform.localScale.x);
            __leftLimit = new Vector2(plateformTransform.position.x - scaledWidth/2, plateformTransform.position.y);
            __rightLimit = new Vector2(plateformTransform.position.x + scaledWidth/2, plateformTransform.position.y );
        }

        // Set up direction
        bool direction = ( Random.Range(0, 1) == 1 );
        if (!!direction)
            __currentDirection = new Vector2(1, 0);
        else
            __currentDirection = new Vector2(-1, 0);

        isMovingLeft = (__currentDirection.x < 0);

        // Retrieve the move controller for further use
        __moveController = GetComponent<MoveController>();
        __moveController.setCurrentDirection(__currentDirection);

    }
    

    // Update is called once per frame
    void Update()
    {

        // Update position
        Transform transform = GetComponent<Transform>();
        Transform plateformTransform = attachedPlateform.GetComponent<Transform>();

        if (!!transform && !!__moveController)
        {

            if ((transform.position.x <= __leftLimit.x) && isMovingLeft)
                flip();
           else if ((transform.position.x >= __rightLimit.x) && !isMovingLeft)
                flip();
            else
                __moveController.move();
        }
    }


    private void flip()
    {
        __currentDirection.x *= (-1);
        isMovingLeft = (__currentDirection.x < 0);
        __moveController.setCurrentDirection( __currentDirection );
    }

}
