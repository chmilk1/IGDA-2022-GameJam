using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentingEmmiter : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    public void fire()
    {
        Instantiate(projectile, transform);
    }
}
