using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{

    [SerializeField] float defaultTime;
    [SerializeField] float defaultStrength;

    public void defaultShake()
    {
        StartCoroutine(shakeC(defaultTime, defaultStrength));
    }

    public void shake(float shakeTime, float strength)
    {
        StartCoroutine(shakeC(shakeTime, strength));
    }

    public IEnumerator shakeC(float shakeTime, float strength)
    {
        Debug.Log("Shakeing");
        Transform target = Camera.main.transform;

        Vector3 origonalPos = target.localPosition;
        float passed = 0.0f;

        while(passed < shakeTime)
        {
            float x = Random.Range(-1f, 1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;

            target.localPosition = new Vector3(x, y, origonalPos.z);

            passed += Time.deltaTime;

            yield return null;
        }

        target.localPosition = origonalPos;
    }
}
