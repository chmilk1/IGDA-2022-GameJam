using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentingEmmiter : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    public void fire()
    {
        GameObject gb = Instantiate(projectile, transform);
        
    }
}
