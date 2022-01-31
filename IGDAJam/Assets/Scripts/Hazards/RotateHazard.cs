using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHazard : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        rb.transform.Rotate(0f, 0f, rotationSpeed);
    }
    
}
