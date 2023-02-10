using UnityEngine;

namespace CharacterController
{
    public class LayerCollisionDetection : ICollisionDetection
    {
        public bool IsCollidingStarted { get; private set; }
        public bool IsColliding { get; private set; }
        public bool IsCollidingEnded { get; private set; }
        public float LastCollided { get; private set;}
        public float LastCollidedDifference => Time.time - LastCollided;
        private LayerMask _detectionLayer { get; }
        private Transform _collisionCenter { get; }
        private float _detectionArea { get; }
        private bool _showDebug { get; }

        public LayerCollisionDetection(LayerDetectionData layerDetectionData)
        {
            _detectionLayer = layerDetectionData.DetectionLayer;
            _collisionCenter = layerDetectionData.CollisionCenter;
            _detectionArea = layerDetectionData.DetectionArea;
            _showDebug = layerDetectionData.ShowDebug;
        }
        
        public void Update()
        {
            if (Physics.OverlapSphere(_collisionCenter.position, _detectionArea, _detectionLayer).Length > 0)
            {
                IsCollidingStarted = !IsColliding;
                IsColliding = true;
                LastCollided = Time.time;
            }
            else
            {
                IsCollidingEnded = !IsColliding;
                IsColliding = false;
            }

            if (_showDebug)
            {
                Debug.Log($"Is Colliding: {IsColliding}");
                Debug.Log($"Last Collided: {LastCollided}");
                Debug.Log($"Last Collided Difference: {LastCollidedDifference}");
            }
        } 
    }
}