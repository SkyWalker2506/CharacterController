using System;
using UnityEngine;

namespace CharacterController
{
    [Serializable]
    public struct LayerDetectionData
    {
        public LayerMask DetectionLayer;
        public Transform CollisionCenter;
        public float DetectionArea;     
    }
}