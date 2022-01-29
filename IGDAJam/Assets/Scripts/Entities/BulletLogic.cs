using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] Vector2 SpawnVelocity;

    private void Awake()
    {
        rigidbody2d.velocity = SpawnVelocity;
    }

    public void onHit()
    {
        Destroy(this.gameObject);
    }
}
