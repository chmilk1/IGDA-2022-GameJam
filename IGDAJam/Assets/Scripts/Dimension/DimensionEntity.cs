using UnityEngine;

namespace Entities
{
    public class DimensionEntity : MonoBehaviour
    {
        [SerializeField] private Dimension currentDimension;
        
        public Dimension CurrentDimension => currentDimension;
        
        
    }
}