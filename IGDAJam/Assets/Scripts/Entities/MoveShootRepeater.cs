using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveShootRepeater : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveTime;
    [SerializeField] float shootWaitTime;

    [SerializeField] float speed;
    private Vector3 xBounds;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] private UnityEvent onTimerEnd;

    private bool isMoving;
    private bool flipped;

    private void Awake()
    {
        if (Camera.main != null)
            xBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private IEnumerator Start()
    {   
        startVelocity();
        while (true)
        {
            yield return new WaitForSeconds(moveTime);
            stopVelocity();
            onTimerEnd.Invoke();
            yield return new WaitForSeconds(shootWaitTime);
            startVelocity();
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            if (transform.position.x < 0)
            {
                flipped = false;
                rigidbody2d.velocity = new Vector2(speed, 0);
            } else if (transform.position.x > xBounds.x)
            {
                flipped = true;
                rigidbody2d.velocity = new Vector2(-speed, 0);
            }
        }
    }

    private void startVelocity()
    {
        isMoving = true;
        rigidbody2d.velocity = new Vector2(speed * (flipped ? -1 : 1), 0);
    }

    private void stopVelocity()
    {
        isMoving = false;
        rigidbody2d.velocity = new Vector2(0, 0);
    }
}
