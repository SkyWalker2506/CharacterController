using System;
using UnityEngine;

namespace CharacterController
{
    [Serializable]
    public struct CharacterControllerData
    {
        [Header("Physics")]
        public PhysicsData PhysicsData;
        [Header("Move")] 
        public MoveData MoveData;
        [Header("Jump")] 
        public JumpData JumpData;
        [Header("Ground Detection")]
        public LayerDetectionData GroundLayerDetectionData;
    }
}