using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace CharacterController
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterControllerData _characterControllerData;
        private IJumpLogic _jumpLogic;
        private ICollisionDetection _groundDetection;

        private void Awake()
        {
            _groundDetection = new LayerCollisionDetection(_characterControllerData.GroundLayerDetectionData);
            _jumpLogic = new JumpLogic(_characterControllerData.JumpData, _groundDetection);
        }

        private void Update()
        {
            _groundDetection.CheckDetection();
        }
    }

    public class JumpLogic : IJumpLogic
    {
        private AnimationCurve _jumpAccelerationCurve;
        private float _maxJumpHeight;        
        private float _jumpAccelerationSpeed;
        private float _coyoteTime;
        private float _jumpBuffer;
        private float _lastJumpButtonClickedTime;
        private bool _isHighestPointReached;
        private ICollisionDetection _groundDetection;
        public JumpLogic(JumpData jumpData, ICollisionDetection groundDetection)
        {
            _jumpAccelerationCurve = jumpData.JumpAccelerationCurve;
            _maxJumpHeight = jumpData.MaxJumpHeight;
            _jumpAccelerationSpeed = jumpData.JumpAccelerationSpeed;
            _coyoteTime = jumpData.CoyoteTime;
            _jumpBuffer = jumpData.JumpBuffer;
            _groundDetection = groundDetection;
        }

        public void Jump()
        {
        }

        private async UniTask TryJump()
        {
            if (_groundDetection.LastCollidedDifference < _coyoteTime)
            {
                await UniTask.DelayFrame(1);
            }
        }

        private void StartJump()
        {
            
        }
    }
}

