using UnityEngine;

namespace Entities
{
    public class InputDimensionSwapper : MonoBehaviour
    {
        [SerializeField] private Dimension[] dimensions;

        private int _currentDimensionIndex;
        private Controls _controls;
        
        private void Awake()
        {
            _controls = new Controls();
            _controls.Enable();
            _controls.Player.Move.started += _ => CycleDimensions();
            
            UpdateActiveDimension();
        }

        private void OnDestroy()
        {
            _controls.Disable();
            _controls.Dispose();
            _controls = null;
        }

        private void CycleDimensions()
        {
            _currentDimensionIndex = (_currentDimensionIndex + 1) % dimensions.Length;
            UpdateActiveDimension();
        }

        private void UpdateActiveDimension()
        {
            
        }
    }
}