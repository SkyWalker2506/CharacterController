using UnityEngine;

namespace CharacterController
{
    public class LayerCollisionDetection : ICollisionDetection
    {
        public bool IsColliding { get; private set; }
        public float LastCollided { get; private set;}
        public float LastCollidedDifference => Time.time - LastCollided;
        public bool ShowDebug => false;
        private LayerMask _detectionLayer { get; }
        private Transform _collisionCenter { get; }
        private float _detectionArea { get; }

        public LayerCollisionDetection(LayerDetectionData layerDetectionData)
        {
            _detectionLayer = layerDetectionData.DetectionLayer;
            _collisionCenter = layerDetectionData.CollisionCenter;
            _detectionArea = layerDetectionData.DetectionArea;
        }
        
        public void CheckDetection()
        {
            if (Physics.OverlapSphere(_collisionCenter.position, _detectionArea, _detectionLayer).Length > 0)
            {
                IsColliding = true;
                LastCollided = Time.time;
            }
            else
            {
                IsColliding = false;
            }

            if (ShowDebug)
            {
                Debug.Log($"Is Colliding: {IsColliding}");
                Debug.Log($"Last Collided: {LastCollided}");
                Debug.Log($"Last Collided Difference: {LastCollidedDifference}");
            }
        } 
    }
}