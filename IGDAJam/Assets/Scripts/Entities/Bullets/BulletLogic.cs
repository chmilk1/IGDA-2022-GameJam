using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;


    private void Awake()
    {
        rigidbody2d.velocity = transform.up * speed;
    }

    public void onHit()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
