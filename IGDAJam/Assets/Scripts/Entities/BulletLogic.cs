using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] private float speed;

    private void Awake()
    {
        rigidbody2d.velocity = transform.right * speed;
    }

    public void onHit()
    {
        Destroy(this.gameObject);
    }
}
