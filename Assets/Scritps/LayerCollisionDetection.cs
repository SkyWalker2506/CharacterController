using UnityEngine;

namespace CharacterController
{
    public class LayerCollisionDetection : ICollisionDetection
    {
        public bool IsColliding { get; }
        public float LastCollided { get; }
        private LayerMask _detectionLayer { get; }
        private Transform _collisionCenter { get; }
        private float _detectionArea { get; }

        public LayerCollisionDetection(LayerMask detectionLayer, Transform collisionCenter, float detectionArea)
        {
            _detectionLayer = detectionLayer;
            _collisionCenter = collisionCenter;
            _detectionArea = detectionArea;
        }
        
        public void CheckDetection()
        {
            
        } 
    }
}