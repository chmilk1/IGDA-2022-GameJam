using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float warmupTime;
    [SerializeField] float activeTime;

    [Header("Dependencies")]
    [SerializeField] BoxCollider2D laserCollider;
    [SerializeField] GameObject laserSprite;
    [SerializeField] GameObject activeLaserSprite;

    private void Awake()
    {
        
    }
}
