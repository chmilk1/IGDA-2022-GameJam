using System.Collections;
using FMODUnity;
using UnityEditor.MemoryProfiler;
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
    [SerializeField] private EventReference shootsound;
    [SerializeField] private UnityEvent onLaserEnd;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(warmupTime);
        RuntimeManager.PlayOneShot(shootsound);
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
