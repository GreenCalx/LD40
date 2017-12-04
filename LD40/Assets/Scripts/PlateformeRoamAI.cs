using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeRoamAI : MonoBehaviour
{
    public RoamablePlateform attachedPlateform;

    private MoveController __moveController;

    private Vector2 __currentDirection;
    private Vector2 __leftLimit;
    private Vector2 __rightLimit;
    private bool isMovingLeft;

    private FixedSizedQueue<float> lastXPositions;
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

        // Simple position tracker
        lastXPositions = new FixedSizedQueue<float>(10);  // Arbitrary cache size ( record 5 last positions )

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.name.Contains("player"))
        {
            flip();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Update position
        Transform transform = GetComponent<Transform>();
        Transform plateformTransform = attachedPlateform.GetComponent<Transform>();

        if (!!transform && !!__moveController)
        {
            float current_x_pos = transform.position.x;

            if ((transform.position.x <= __leftLimit.x) && isMovingLeft)
                flip();
           else if ((transform.position.x >= __rightLimit.x) && !isMovingLeft)
                flip();
            else
                __moveController.move();

            lastXPositions.enqueue(current_x_pos);

            if (isStuck())
                flip();
        }
    }


    private void flip()
    {
        __currentDirection.x *= (-1);
        isMovingLeft = (__currentDirection.x < 0);
        __moveController.setCurrentDirection( __currentDirection );
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.flipX = !sr.flipX;
    }

    private bool isStuck()
    {
        float ref_x_position = lastXPositions.getValueAtIndex(0);
        for (int i=1; i < lastXPositions.Limit; ++i)
        {
            if (ref_x_position != lastXPositions.getValueAtIndex(i))
                return false;
        }

        return true;
    }
}
    