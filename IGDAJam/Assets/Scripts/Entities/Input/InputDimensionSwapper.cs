using UnityEngine;
using UnityEngine.InputSystem;
using Display = UI.Display;

namespace Entities
{
    public class InputDimensionSwapper : MonoBehaviour
    {
        [SerializeField] private Dimension[] dimensions;
        [SerializeField] private Display currentDimensionDisplay;
        
        private int _currentDimensionIndex;
        
        private void Start()
        {
            foreach (var dimension in dimensions)
                dimension.Exit();

            UpdateDimensionIndex(0);
        }

        private void OnDestroy()
        {
            currentDimensionDisplay.UpdateText("");
        }

        public void CycleDimensions(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                int targetIndex = (_currentDimensionIndex + 1) % dimensions.Length;
                UpdateDimensionIndex(targetIndex);    
            }
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