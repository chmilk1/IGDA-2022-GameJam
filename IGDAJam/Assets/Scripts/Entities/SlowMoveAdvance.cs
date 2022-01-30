using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlowMoveAdvance : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField,Range(0,1)] float yScreenPrecent;
    private Vector3 xBounds;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D rigidbody2d;

    private bool isMoving;
    private bool isMovingY;
    private bool flipped;

    private void Awake()
    {
        startVelocity();
        if (Camera.main != null)
            xBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if (isMoving)
        {
            if (transform.position.x < .5)
            {
                flipped = false;
                rigidbody2d.velocity = new Vector2(xSpeed, ySpeed * (isMovingY ? 1 : 0));
            }
            else if (transform.position.x > xBounds.x - .5)
            {
                flipped = true;
                rigidbody2d.velocity = new Vector2(-xSpeed, ySpeed * (isMovingY ? 1 : 0));
            }

            if (isMovingY && transform.position.x < xBounds.y*yScreenPrecent)
            {
                isMovingY = false;
                rigidbody2d.velocity = new Vector2(xSpeed * (flipped ? -1 : 1), 0);
            }
        }
    }

    private void startVelocity()
    {
        isMoving = true;
        rigidbody2d.velocity = new Vector2(xSpeed * (flipped ? -1 : 1), ySpeed * (isMovingY ? 1 : 0));
    }

    private void stopVelocity()
    {
        isMoving = false;
        rigidbody2d.velocity = new Vector2(0, 0);
    }
}
