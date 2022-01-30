using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Repeater : MonoBehaviour
{

    [SerializeField] float timeInterval;
    [SerializeField] private UnityEvent onTimerEnd;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        while (true)
        {
            onTimerEnd.Invoke();
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
