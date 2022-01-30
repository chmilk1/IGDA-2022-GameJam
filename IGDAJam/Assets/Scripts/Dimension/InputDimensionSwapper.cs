using UnityEngine;
using Display = UI.Display;

namespace Entities
{
    public class InputDimensionSwapper : MonoBehaviour
    {
        [SerializeField] private Dimension[] dimensions;
        [SerializeField] private Display currentDimensionDisplay;
        
        private int _currentDimensionIndex;
        private Controls _controls;
        
        private void Start()
        {
            foreach (var dimension in dimensions)
                dimension.Exit();

            UpdateDimensionIndex(0);
            
            _controls = new Controls();
            _controls.Enable();
            _controls.Player.CycleDimension.started += _ => CycleDimensions();
        }

        private void OnDestroy()
        {
            currentDimensionDisplay.UpdateText("");
            
            _controls.Disable();
            _controls.Dispose();
            _controls = null;
        }

        private void CycleDimensions()
        {
            int targetIndex = (_currentDimensionIndex + 1) % dimensions.Length;
            UpdateDimensionIndex(targetIndex);
        }

        private void UpdateDimensionIndex(int index)
        {
            dimensions[_currentDimensionIndex].Exit();
            _currentDimensionIndex = index;
            dimensions[_currentDimensionIndex].Enter();
            
            currentDimensionDisplay.UpdateText($"Current Dimension: {dimensions[_currentDimensionIndex].name}");
        }
    }
}