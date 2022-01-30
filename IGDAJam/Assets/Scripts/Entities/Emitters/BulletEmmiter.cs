using UnityEngine;

public class BulletEmmiter : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    public void fire()
    {
        Instantiate(projectile,transform.position,transform.rotation);
    }
}
