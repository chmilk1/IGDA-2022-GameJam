using FMODUnity;
using UnityEngine;

public class BulletEmmiter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] private EventReference shootSound;
    
    public void fire()
    {
        RuntimeManager.PlayOneShot(shootSound);
        Instantiate(projectile,transform.position,transform.rotation);
    }
}
