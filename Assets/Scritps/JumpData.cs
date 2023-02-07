using System;
using UnityEngine;

namespace CharacterController
{
    [Serializable]
    public struct JumpData
    {
        public AnimationCurve JumpAccelerationCurve;
        public float MaxJumpHeight;        
        public float JumpAccelerationSpeed;
        public float CoyoteTime;
        public float JumpBuffer;
    }
}