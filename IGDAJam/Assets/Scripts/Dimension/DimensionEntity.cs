using System;
using UnityEngine;
using UnityEngine.Events;

namespace Entities
{
    public class DimensionEntity : MonoBehaviour
    {
        [SerializeField] private Dimension currentDimension;
        
        [Space(20f)]
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        
        public Dimension CurrentDimension => currentDimension;

        private void OnEnable()
        {
            if (currentDimension.IsActive)
                HandleOnEnter();
            
            else HandleOnExit();
            
            currentDimension.OnEnter += HandleOnEnter;
            currentDimension.OnExit += HandleOnExit;
        }

        private void OnDisable()
        {
            currentDimension.OnEnter -= HandleOnEnter;
            currentDimension.OnExit -= HandleOnExit;
        }

        private void HandleOnEnter()
        {
            onEnter.Invoke();
        }

        private void HandleOnExit()
        {
            onExit.Invoke();
        }
    }
}