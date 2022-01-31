using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LaserLogic : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float warmupTime;
    [SerializeField] float activeTime;

    [Header("Dependencies")]
    [SerializeField] GameObject laserSprite;
    [SerializeField] GameObject activeLaserSprite;
    [SerializeField] private UnityEvent onLaserEnd;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(warmupTime);
        activateLaser();
        yield return new WaitForSeconds(activeTime);
        onLaserEnd.Invoke();

    }

    public void distroyThis()
    {
        Destroy(this.gameObject);
    }

    private void activateLaser()
    {
        laserSprite.SetActive(false);
        activeLaserSprite.SetActive(true);
    }
}
