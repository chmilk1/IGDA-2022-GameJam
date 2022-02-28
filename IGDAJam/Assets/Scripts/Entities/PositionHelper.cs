using UnityEngine;

namespace Entities
{
    public static class PositionHelper
    {
        public static Bounds CalculateWorldBounds(float padding = 0)
        {
            var camera = Camera.main;
            
            if (camera != null)
            {
                Vector3 cameraPosition = camera.transform.position;
                Vector3 screenBounds = new Vector3(Screen.width - padding * 2, Screen.height - padding * 2);
                Vector3 worldBounds = camera.ScreenToWorldPoint(screenBounds);
                
                return new Bounds(new Vector3(cameraPosition.x, cameraPosition.y, 0), worldBounds);
            }

            return default;
        }

        public static Vector3 RandomPointInBounds(Bounds bounds)
        {
            Vector3 randomPosition = Vector3.zero;
            randomPosition.x = Random.Range(-bounds.extents.x, bounds.extents.x);
            randomPosition.y = Random.Range(-bounds.extents.y, bounds.extents.y);
            
            return randomPosition;
        }
    }
}