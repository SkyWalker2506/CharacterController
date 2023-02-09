using System;
using UnityEngine;

namespace CharacterController
{
    [Serializable]
    public class JumpData
    {
        public AnimationCurve JumpAccelerationCurve;
        public float MaxJumpForce;        
        public float JumpAccelerationSpeed;
        public float CoyoteTime;
        public float JumpBuffer;
        public int JumpLimitBeforeGrounded;
    }
}