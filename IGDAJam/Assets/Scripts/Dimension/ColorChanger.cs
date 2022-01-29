using UnityEngine;

namespace Entities
{
    public class ColorChanger : MonoBehaviour
    {
        public SpriteRenderer targetRenderer;
        public Color activeColor;
        public Color inactiveColor;

        public void SetColorActive(bool active)
        {
            targetRenderer.color = active ? activeColor : inactiveColor;
        }
    }
}