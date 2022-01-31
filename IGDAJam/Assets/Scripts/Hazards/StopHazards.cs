using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopHazards : MonoBehaviour
{
    public GameObject hazards;

    void Start()
    {
        hazards.GetComponent<DeployEnemy>().stopHazards();
    }

}
