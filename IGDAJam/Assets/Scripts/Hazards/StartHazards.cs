using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHazards : MonoBehaviour
{
    public GameObject hazards;

    void Start()
    {
        hazards.GetComponent<DeployEnemy>().startHazards();
    }

}
