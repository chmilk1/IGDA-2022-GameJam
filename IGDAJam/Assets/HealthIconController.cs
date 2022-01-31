using System.Collections.Generic;
using Entities;
using UnityEngine;

public class HealthIconController : MonoBehaviour
{
    public Health playerHealth;
    public GameObject healthPrefab;

    private Stack<GameObject> _icons = new Stack<GameObject>();

    private void Start()
    {
        playerHealth.onDamage.AddListener(UpdateHealth);
        playerHealth.onHeal.AddListener(UpdateHealth);
        
        UpdateHealth(playerHealth);
    }

    private void UpdateHealth(Health health)
    {
        int change = _icons.Count - health.RemainingHitPoints;

        for (int i = 0; i < Mathf.Abs(change); i++)
        {
            if (change < 0)
                _icons.Push(Instantiate(healthPrefab, transform));

            if (change > 0)
                Destroy(_icons.Pop());
        }
    }
}
