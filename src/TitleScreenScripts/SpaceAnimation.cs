using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceAnimation : MonoBehaviour
{
    private Vector3 movementX;
    private Vector3 movementY;

    private float movementSpeedX = 0.1f;
    private float movementChangeX = 5.0f;
    private float tempMovementChangeX;
    private float movementSpeedY = 0.03f;
    private float movementChangeY = 3.0f;
    private float tempMovementChangeY;
    private void Awake()
    {
        movementX = new Vector3(movementSpeedX, 0);
        movementY = new Vector3(0, movementSpeedY);

        tempMovementChangeX = movementChangeX;
        tempMovementChangeY = movementChangeY;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        tempMovementChangeX -= Time.deltaTime;
        tempMovementChangeY -= Time.deltaTime;

        if (tempMovementChangeX < 0)
        {
            movementX = -movementX;
            tempMovementChangeX = movementChangeX;
        }
        if (tempMovementChangeY < 0)
        {
            movementY = -movementY;
            tempMovementChangeY = movementChangeY;
        }

        transform.position += movementX;
        transform.position += movementY;
    }
}
