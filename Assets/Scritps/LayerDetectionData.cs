using System;
using UnityEngine;

namespace CharacterController
{
    [Serializable]
    public class LayerDetectionData
    {
        public LayerMask DetectionLayer;
        public Transform CollisionCenter;
        public float DetectionArea;
        public bool ShowDebug;
    }
}