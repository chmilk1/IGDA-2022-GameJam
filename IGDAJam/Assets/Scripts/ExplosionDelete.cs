using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDelete : MonoBehaviour
{
    [SerializeField] float lifetime;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(this.gameObject);
        }
    }
}
