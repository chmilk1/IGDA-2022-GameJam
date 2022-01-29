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
            _controls.Player.CycleDimension.started += _ => CycleDimensions();
        }

        private void OnDestroy()
        {
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
        }

        private void OnGUI()
        {
            GUILayout.Label($"Current dimension: {dimensions[_currentDimensionIndex].name}");
        }
    }
}