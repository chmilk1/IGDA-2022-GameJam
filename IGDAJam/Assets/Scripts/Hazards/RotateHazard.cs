using UnityEngine;

public class RotateHazard : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        rb.angularVelocity = rotationSpeed;
    }
}
