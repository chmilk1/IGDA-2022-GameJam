using System;
using System.Collections;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace Entities
{
    public class InputDimensionSwapper : MonoBehaviour
    {
        [Serializable]
        public class DimensionData
        {
            public Dimension dimension;
            public GameObject playerShip;
            public GameObject background;
            public Volume volume;
        }

        [SerializeField] private DimensionData[] dimensions;
        [SerializeField] private Volume transitionVolume;
        [SerializeField] private PlayerInput input;
        [SerializeField] private StudioEventEmitter swapSound;
        
        private int _currentDimensionIndex;
        
        private void Start()
        {
            foreach (var dimension in dimensions)
            {
                dimension.dimension.Exit();
                dimension.playerShip.SetActive(false);
                dimension.background.SetActive(false);
                dimension.volume.weight = 0;
            }
            
            _currentDimensionIndex = 0;
            
            dimensions[_currentDimensionIndex].dimension.Enter();
            dimensions[_currentDimensionIndex].playerShip.SetActive(true);
            dimensions[_currentDimensionIndex].background.SetActive(true);
            dimensions[_currentDimensionIndex].volume.weight = 1;
            
        }

        public void CycleDimensions(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                int targetIndex = (_currentDimensionIndex + 1) % dimensions.Length;
                StartCoroutine(UpdateDimensionIndex(targetIndex));    
            }
        }

        private IEnumerator UpdateDimensionIndex(int index)
        {
            input.DeactivateInput();
            float elapsedTime = 0;
            swapSound.Play();

            while (elapsedTime <= 1.1f)
            {
                float percentDone = Mathf.Lerp(0, 1, elapsedTime / 1.1f);
                transitionVolume.weight = percentDone;
                dimensions[_currentDimensionIndex].volume.weight = 1 - percentDone;
                dimensions[_currentDimensionIndex].playerShip.transform.localScale = Vector3.one * (1 - percentDone);
                
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            elapsedTime = 0;
            dimensions[_currentDimensionIndex].dimension.Exit();
            dimensions[_currentDimensionIndex].playerShip.SetActive(false);
            dimensions[_currentDimensionIndex].background.SetActive(false);

            _currentDimensionIndex = index;

            dimensions[_currentDimensionIndex].dimension.Enter();
            dimensions[_currentDimensionIndex].playerShip.SetActive(true);
            dimensions[_currentDimensionIndex].background.SetActive(true);

            while (elapsedTime <= 0.65f)
            {
                float percentDone = Mathf.Lerp(0, 1, elapsedTime / 0.65f);
                transitionVolume.weight = 1 - percentDone;
                dimensions[_currentDimensionIndex].volume.weight = percentDone;
                dimensions[_currentDimensionIndex].playerShip.transform.localScale = Vector3.one * percentDone;
                
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            input.ActivateInput();
        }
    }
}